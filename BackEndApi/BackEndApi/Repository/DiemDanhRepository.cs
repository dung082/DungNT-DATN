using BackEndApi.Dto;
using BackEndApi.Interface.IRepository;
using BackEndData;
using BackEndData.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.WebSockets;

namespace BackEndApi.Repository
{
    public class DiemDanhRepository : IDiemDanhRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IThongBaoRepository _iThongBaoRepository;

        public DiemDanhRepository(ApplicationDbContext context, IThongBaoRepository iThongBaoRepository)
        {
            _context = context;
            _iThongBaoRepository = iThongBaoRepository;
        }

        public async Task<ActionResult> ChiTietDiemDanh(Guid diemDanhId)
        {
            return new JsonResult(true);
        }

        public async Task<ActionResult> DuyetDiemDanh(Guid diemDanhId)
        {
            var diemDanh = await _context.DiemDanhs.FirstOrDefaultAsync(i => i.Id == diemDanhId);
            if (diemDanh == null)
            {
                throw new Exception("Không tồn tại đơn xin nghỉ");
            }
            diemDanh.TrangThai = 1;
            ThongBaoDto tbdto = new ThongBaoDto()
            {
                Content = "Đơn xin nghỉ của bạn đã được duyệt thành công. Vui lòng vào trang /DiemDanhXinNghi để kiểm tra lại",
                Link = "/DiemDanhXinNghi",
                LopId = null,
                NamHoc = null,
                Status = 0 ,
                Title = "Xác nhận đơn xin nghỉ học",
                Username = diemDanh.Username,
            };
            var tb = await _iThongBaoRepository.ThemThongBao(tbdto);

            _context.DiemDanhs.Update(diemDanh);
            _context.SaveChanges();

            return new JsonResult(true);
        }

        public async Task<ActionResult> LayDanhSachDiemDanhTheoTuan(DateTime? ngay, string username)
        {
            Dictionary<string, List<DiemDanh>> listdd = new Dictionary<string, List<DiemDanh>>();
            List<DiemDanh> diemDanhSang = new List<DiemDanh>();
            List<DiemDanh> diemDanhChieu = new List<DiemDanh>();
            DateOnly[] weekDays = new DateOnly[7];
            string namhoc = "";
            if (String.IsNullOrWhiteSpace(ngay.ToString()))
            {
                var today = DateTime.Now;

                // Thiết lập thứ Hai là ngày đầu tuần
                DayOfWeek firstDayOfWeek = DayOfWeek.Monday;

                // Tính toán ngày đầu tiên và ngày cuối cùng của tuần
                int offset = today.DayOfWeek - firstDayOfWeek;
                if (offset < 0) offset += 7;  // Điều chỉnh cho trường hợp DayOfWeek.Sunday

                DateOnly weekStart = DateOnly.FromDateTime(today.AddDays(-offset));
                DateOnly weekEnd = weekStart.AddDays(6);

                // Tạo mảng chứa các ngày trong tuần
                for (int i = 0; i < 7; i++)
                {
                    weekDays[i] = weekStart.AddDays(i);

                }

                if (weekDays[0].Month >= 10)
                {
                    namhoc = weekDays[0].Year.ToString() + "-" + (weekDays[0].Year + 1).ToString();
                }
                else
                {
                    namhoc = (weekDays[0].Year - 1).ToString() + "-" + weekDays[0].Year.ToString();
                }

            }
            else
            {
                DateTime date = ngay.Value;
                DayOfWeek firstDayOfWeek = DayOfWeek.Monday;

                // Tính toán ngày đầu tiên và ngày cuối cùng của tuần
                int offset = date.DayOfWeek - firstDayOfWeek;
                if (offset < 0) offset += 7;  // Điều chỉnh cho trường hợp DayOfWeek.Sunday

                DateOnly weekStart = DateOnly.FromDateTime(date.AddDays(-offset));
                DateOnly weekEnd = weekStart.AddDays(6);

                // Tạo mảng chứa các ngày trong tuần
                for (int i = 0; i < 7; i++)
                {
                    weekDays[i] = weekStart.AddDays(i);
                }

                if (weekDays[0].Month >= 8)
                {
                    namhoc = weekDays[0].Year.ToString() + "-" + (weekDays[0].Year + 1).ToString();
                }
                else
                {
                    namhoc = (weekDays[0].Year - 1).ToString() + "-" + weekDays[0].Year.ToString();

                }
            }

            var IdCaSang = await _context.CaHocs.Where(item => item.TenCaHoc.Trim().ToLower() == "Ca sáng".ToLower()).Select(i => i.Id).FirstOrDefaultAsync();
            var IdCaChieu = await _context.CaHocs.Where(item => item.TenCaHoc.Trim().ToLower() == "Ca chiều".ToLower()).Select(i => i.Id).FirstOrDefaultAsync();
            foreach (var item in weekDays)
            {
                var ddSang = await _context.DiemDanhs.FirstOrDefaultAsync(i => DateOnly.FromDateTime(i.NgayHoc) == item && i.CaHocId == IdCaSang && i.Username == username);
                var ddchieu = await _context.DiemDanhs.FirstOrDefaultAsync(i => DateOnly.FromDateTime(i.NgayHoc) == item && i.CaHocId == IdCaChieu && i.Username == username);
                diemDanhSang.Add(ddSang);
                diemDanhChieu.Add(ddchieu);
            }
            listdd.Add("S", diemDanhSang);
            listdd.Add("C", diemDanhChieu);

            var result = new
            {
                ngay = weekDays,
                dd = listdd,
            };
            return new JsonResult(result);
        }

        public async Task<ActionResult> SuaDiemDanh(DiemDanh diemDanh)
        {
            var diemdanh = await _context.DiemDanhs.FirstOrDefaultAsync(item => item.Id == diemDanh.Id);
            if (diemdanh == null)
            {
                throw new Exception("Điểm danh không tồn tại");
            }
            diemdanh.LyDo = diemDanh.LyDo;
            _context.DiemDanhs.Update(diemdanh);
            _context.SaveChanges();
            return new JsonResult(diemdanh);
        }

        public async Task<ActionResult> ThemDiemDanh(DiemDanhDto diemDanhDto)
        {
            var ngd = await _context.NguoiDungs.FirstOrDefaultAsync(i => i.Username == diemDanhDto.Username);
            if (ngd == null)
            {
                throw new Exception("Người dùng không tồn tại");
            }

            var cahoc = await _context.CaHocs.FirstOrDefaultAsync(i => i.Id == diemDanhDto.CaHocId);
            if (cahoc == null)
            {
                throw new Exception("Ca học không tồn tại");
            }

            if(DateOnly.FromDateTime(diemDanhDto.NgayHoc) < DateOnly.FromDateTime(DateTime.Now))
            {
                throw new Exception("Bạn không thể xin nghỉ những ngày đã qua");
            }

            var caHocSang = await _context.CaHocs.Where(i => i.TenCaHoc.Contains("sáng")).Select(i => i.Id).FirstOrDefaultAsync();
            if(caHocSang == diemDanhDto.CaHocId )
            {
                throw new Exception("Bạn không thể xin nghỉ buổi học đã qua");
            }
            

            var ddtrung = await _context.DiemDanhs.FirstOrDefaultAsync(i => i.CaHocId == diemDanhDto.CaHocId && i.Username == diemDanhDto.Username && DateOnly.FromDateTime(i.NgayHoc) == DateOnly.FromDateTime(diemDanhDto.NgayHoc));
            if (ddtrung != null)
            {
                throw new Exception("Học sinh đã có lịch điểm danh vào buổi học này");
            }



            DiemDanh diemdanh = new DiemDanh()
            {
                Id = Guid.NewGuid(),
                Username = diemDanhDto.Username,
                CaHocId = diemDanhDto.CaHocId,
                LyDo = diemDanhDto.LyDo,
                NgayHoc = diemDanhDto.NgayHoc,
                TrangThai = diemDanhDto.TrangThai
            };

            ThongBaoDto tbDto = new ThongBaoDto()
            {
                Username = "admin_truong_dungnt",
                Title = "Đơn xin nghỉ học",
                Content = "Hiện đang có thông tin học sinh đang xin nghỉ học.Vui lòng vào trang /DiemDanhHS để chấp nhận đơn xin nghỉ học của học sinh",
                Link = "/DiemDanhHS",
                LopId = null,
                NamHoc = null,
                Status = 0
            };


            var addTb = await _iThongBaoRepository.ThemThongBao(tbDto);

            _context.DiemDanhs.Add(diemdanh);
            _context.SaveChanges();

            return new JsonResult(diemdanh);
        }

        public async Task<ActionResult> XoaDiemDanh(Guid diemDanhId)
        {
            var diemdanh = await _context.DiemDanhs.FirstOrDefaultAsync(item => item.Id == diemDanhId);
            if (diemdanh == null)
            {
                throw new Exception("Điểm danh không tồn tại");
            }
            _context.DiemDanhs.Remove(diemdanh);
            _context.SaveChanges();
            return new JsonResult(diemdanh);
        }
    }
}
