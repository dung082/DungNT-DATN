using BackEndApi.Dto;
using BackEndApi.Interface.IRepository;
using BackEndData;
using BackEndData.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEndApi.Repository
{
    public class DiemDanhRepository : IDiemDanhRepository
    {
        private readonly ApplicationDbContext _context;

        public DiemDanhRepository(ApplicationDbContext context)
        {
            _context = context;
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

                if (weekDays[0].Month >= 8)
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
                var ddchieu = await _context.DiemDanhs.FirstOrDefaultAsync(i => DateOnly.FromDateTime(i.NgayHoc) == item && i.CaHocId == IdCaSang && i.Username == username);
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

            _context.DiemDanhs.Add(diemdanh);
            _context.SaveChanges();

            return new JsonResult(diemdanh);
        }
    }
}
