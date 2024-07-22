using BackEndApi.Dto;
using BackEndApi.Interface.IRepository;
using BackEndData;
using BackEndData.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEndApi.Repository
{
    public class LichThiRepository : ILichThiRepository
    {
        private readonly ApplicationDbContext _context;

        public LichThiRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ActionResult> LayLichThi(DateTime? ngayThi, string username)
        {
            Dictionary<string, List<List<LichThiViewDto>>> list = new Dictionary<string, List<List<LichThiViewDto>>>();
            List<List<LichThiViewDto>> listLichThiSang = new List<List<LichThiViewDto>>();
            List<List<LichThiViewDto>> listLichThiChieu = new List<List<LichThiViewDto>>();
            DateOnly[] weekDays = new DateOnly[7];
            string namhoc = "";
            KyThi kyThi = new KyThi();
            if (String.IsNullOrWhiteSpace(ngayThi.ToString()))
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

                if (weekDays[0].Month >= 8)
                {
                    namhoc = weekDays[0].Year.ToString() + "-" + (weekDays[0].Year + 1).ToString();
                }
                else
                {
                    namhoc = (weekDays[0].Year - 1).ToString() + "-" + weekDays[0].Year.ToString();
                }

                kyThi = await _context.KyThis.FirstOrDefaultAsync(item => DateOnly.FromDateTime(item.NgayBatDau) < weekDays[0] && DateOnly.FromDateTime(item.NgayKetThuc) > weekDays[0]);

            }
            else
            {
                DateTime date = ngayThi.Value;
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
                kyThi = await _context.KyThis.FirstOrDefaultAsync(item => DateOnly.FromDateTime(item.NgayBatDau) < weekDays[0] && DateOnly.FromDateTime(item.NgayKetThuc) > weekDays[0]);

                // Thiết lập thứ Hai là ngày đầu tuần
            }

            var IdCaSang = await _context.CaHocs.Where(item => item.TenCaHoc.Trim().ToLower() == "Ca sáng".ToLower()).Select(i => i.Id).FirstOrDefaultAsync();
            //var IdCaChieu = await _context.CaHocs.FirstOrDefaultAsync(item => item.TenCaHoc.Trim().ToLower() == "Ca chiều".ToLower());
            var lopId = await _context.ChiTietLops.Where(item => item.Username == username && item.NamHoc == namhoc).FirstOrDefaultAsync();
            var lop = await _context.Lops.FirstOrDefaultAsync(i => i.Id == lopId.LopId);
            var listMonThiTheoLop = await _context.MonThis.Where(item => item.KhoiThi == "" || item.KhoiThi == lop.KhoiHoc).Select(i => i.Id).ToListAsync();
            foreach (var item in weekDays)
            {
                var lstLichThi = await _context.LichThis.Where(item1 => DateOnly.FromDateTime(item1.NgayThi) == item && item1.KhoiThi == lop.Khoi && listMonThiTheoLop.Contains(item1.MonThiId)).ToListAsync();
                List<LichThiViewDto> lstLichThiSangDto = new List<LichThiViewDto>();
                List<LichThiViewDto> lstLichThiChieuDto = new List<LichThiViewDto>();
                foreach (var tkb in lstLichThi)
                {
                    var cahoc = await _context.CaHocs.FirstOrDefaultAsync(item => item.Id == tkb.CaHocId);
                    var monthi = await _context.MonThis.FirstOrDefaultAsync(item => item.Id == tkb.MonThiId);
                    var kythi = await _context.KyThis.FirstOrDefaultAsync(item => item.Id == tkb.KyThiId);
                    LichThiViewDto lichThiView = new LichThiViewDto()
                    {
                        Id = tkb.Id,
                        CaHocId = tkb.CaHocId,
                        TenCaHoc = cahoc.TenCaHoc,
                        KhoiHoc = tkb.KhoiHoc,
                        KhoiThi = tkb.KhoiThi,
                        TenMonThi = monthi.TenMonThi,
                        MonThiId = tkb.MonThiId,
                        KyThiId = tkb.KyThiId,
                        NgayThi = tkb.NgayThi,
                        TenKyThi = kythi.TenKyThi,
                        ThoiGianBatDau = tkb.ThoiGianBatDau,
                        ThoiGianKetThuc = tkb.ThoiGianKetThuc,
                    };

                    if (tkb.CaHocId == IdCaSang)
                    {
                        lstLichThiSangDto.Add(lichThiView);

                    }
                    else
                    {
                        lstLichThiChieuDto.Add(lichThiView);
                    }
                }
                lstLichThiSangDto = lstLichThiSangDto.OrderBy(u =>new TimeOnly(Int32.Parse(u.ThoiGianBatDau.Split(":")[0]), Int32.Parse(u.ThoiGianBatDau.Split(":")[1]))).ToList();
                lstLichThiChieuDto = lstLichThiChieuDto.OrderBy(u => new TimeOnly(Int32.Parse(u.ThoiGianBatDau.Split(":")[0]), Int32.Parse(u.ThoiGianBatDau.Split(":")[1]))).ToList();
                listLichThiSang.Add(lstLichThiSangDto);
                listLichThiChieu.Add(lstLichThiChieuDto);
            }

            list.Add("S", listLichThiSang);
            list.Add("C", listLichThiChieu);

            var lopHt = await _context.Lops.FirstOrDefaultAsync(item => item.Id == lopId.LopId);
            var result = new
            {
                ngay = weekDays,
                data = list,
                lopObj = lopHt,
                namHoc = namhoc,
                kythi = kyThi,
            };

            return new JsonResult(result);
        }

        public async Task<ActionResult> ThemLichThi(LichThiDto lichThiDto)
        {
            var kythi = await _context.KyThis.FirstOrDefaultAsync(item => item.Id == lichThiDto.KyThiId);
            if (kythi == null)
            {
                throw new Exception("Kỳ thi không tồn tại");
            }
            var cahoc = await _context.CaHocs.FirstOrDefaultAsync(item => item.Id == lichThiDto.CaHocId);
            if (cahoc == null)
            {
                throw new Exception("Ca học không tồn tại");
            }
            var monthi = await _context.MonThis.FirstOrDefaultAsync(item => item.Id == lichThiDto.MonThiId);
            if (monthi == null)
            {
                throw new Exception("Môn thi không tồn tại");
            }
            if (DateOnly.FromDateTime(lichThiDto.NgayThi) < DateOnly.FromDateTime(kythi.NgayBatDau) || DateOnly.FromDateTime(lichThiDto.NgayThi) > DateOnly.FromDateTime(kythi.NgayKetThuc))
            {
                throw new Exception("Thời gian thi đã nằm ngoài lịch thi");
            }

            LichThi lichthi = new LichThi()
            {
                Id = Guid.NewGuid(),
                CaHocId = lichThiDto.CaHocId,
                KhoiHoc = lichThiDto.KhoiHoc,
                KhoiThi = lichThiDto.KhoiThi,
                KyThiId = lichThiDto.KyThiId,
                MonThiId = lichThiDto.MonThiId,
                NgayThi = lichThiDto.NgayThi,
                ThoiGianBatDau = lichThiDto.ThoiGianBatDau,
                ThoiGianKetThuc = lichThiDto.ThoiGianKetThuc,
            };
            _context.LichThis.Add(lichthi);
            _context.SaveChanges();
            return new JsonResult(lichthi);
        }
    }
}
