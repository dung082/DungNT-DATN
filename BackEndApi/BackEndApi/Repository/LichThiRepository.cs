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

        public async Task<ActionResult> ChiTietLichThi(Guid lichThiId, string username)
        {
            List<Guid> listMaLop = new List<Guid>();
            List<NguoiDung> listNguoiDung = new List<NguoiDung>();
            List<List<NguoiDung>> listNguoiDungPhongThi = new List<List<NguoiDung>>();
            var lichThi = await _context.LichThis.FirstOrDefaultAsync(i => i.Id == lichThiId);
            var ngd = await _context.NguoiDungs.FirstOrDefaultAsync(i => i.Username == username);
            if (lichThi == null)
            {
                return new JsonResult(null);
            }

            var cahoc = await _context.CaHocs.FirstOrDefaultAsync(item => item.Id == lichThi.CaHocId);
            var monthi = await _context.MonThis.FirstOrDefaultAsync(item => item.Id == lichThi.MonThiId);
            var kythi = await _context.KyThis.FirstOrDefaultAsync(item => item.Id == lichThi.KyThiId);
            var kyhoc = await _context.KyHocs.FirstOrDefaultAsync(item => item.Id == kythi.KyHocId);

            if (String.IsNullOrWhiteSpace(monthi.KhoiThi) || monthi.KhoiThi == "" || monthi.KhoiThi == null)
            {
                listMaLop = await _context.Lops.Where(i => i.Khoi == lichThi.KhoiThi).Select(item => item.Id).ToListAsync();
            }
            else
            {
                listMaLop = await _context.Lops.Where(i => i.KhoiHoc == monthi.KhoiThi && i.Khoi == lichThi.KhoiThi).Select(item => item.Id).ToListAsync();
            }

            var listHS = await _context.ChiTietLops.Where(i => listMaLop.Contains(i.LopId) && i.NamHoc == kyhoc.NamHoc).ToListAsync();
            foreach (var hs in listHS)
            {
                var nguoiDungHS = await _context.NguoiDungs.FirstOrDefaultAsync(item => item.Username == hs.Username && item.UserType == 2);
                listNguoiDung.Add(nguoiDungHS);
            }

            listNguoiDung = listNguoiDung.OrderBy(u => u.HoTen.Split()[u.HoTen.Split().Length - 1]).ToList();

            var vitri = listNguoiDung.FindIndex(i => i.Username == username);
            var phongthi = vitri / 24;

            LichThiViewDto lichThiView = new LichThiViewDto()
            {
                Id = lichThi.Id,
                CaHocId = lichThi.CaHocId,
                TenCaHoc = cahoc.TenCaHoc,
                KhoiHoc = lichThi.KhoiHoc,
                KhoiThi = lichThi.KhoiThi,
                TenMonThi = monthi.TenMonThi,
                MonThiId = lichThi.MonThiId,
                KyThiId = lichThi.KyThiId,
                NgayThi = lichThi.NgayThi,
                TenKyThi = kythi.TenKyThi,
                ThoiGianBatDau = lichThi.ThoiGianBatDau,
                ThoiGianKetThuc = lichThi.ThoiGianKetThuc,
                PhongThi = phongthi + 1
            };



            int sophongthi = listNguoiDung.Count / 24;
            int soHsTrongPhongThiCuoi = listNguoiDung.Count % 24;

            for (int i = 0; i < sophongthi; i++)
            {
                if (i != sophongthi - 1)
                {
                    List<NguoiDung> lstng = new List<NguoiDung>();
                    for (int j = i * 24; j < (i + 1) * 24; j++)
                    {
                        lstng.Add(listNguoiDung[j]);
                    }
                    listNguoiDungPhongThi.Add(lstng);
                }
                else
                {
                    List<NguoiDung> lstng = new List<NguoiDung>();
                    for (int j = i * 24; j < i * 24 + soHsTrongPhongThiCuoi; j++)
                    {
                        lstng.Add(listNguoiDung[j]);
                    }
                    listNguoiDungPhongThi.Add(lstng);
                }
            }


            var result = new
            {
                lichthi = lichThiView,
                listngdphongthi = listNguoiDungPhongThi,
            };

            return new JsonResult(result);
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

                if (weekDays[0].Month >= 10)
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

                if (weekDays[0].Month >= 10)
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
                    List<Guid> listMaLop = new List<Guid>();
                    List<NguoiDung> listNguoiDung = new List<NguoiDung>();
                    var cahoc = await _context.CaHocs.FirstOrDefaultAsync(item => item.Id == tkb.CaHocId);
                    var monthi = await _context.MonThis.FirstOrDefaultAsync(item => item.Id == tkb.MonThiId);
                    var kythi = await _context.KyThis.FirstOrDefaultAsync(item => item.Id == tkb.KyThiId);
                    var kyhoc = await _context.KyHocs.FirstOrDefaultAsync(item => item.Id == kythi.KyHocId);

                    if (String.IsNullOrWhiteSpace(monthi.KhoiThi) || monthi.KhoiThi == "" || monthi.KhoiThi == null)
                    {
                        listMaLop = await _context.Lops.Where(i => i.Khoi == tkb.KhoiThi).Select(item => item.Id).ToListAsync();
                    }
                    else
                    {
                        listMaLop = await _context.Lops.Where(i => i.KhoiHoc == monthi.KhoiThi && i.Khoi == tkb.KhoiThi).Select(item => item.Id).ToListAsync();
                    }

                    var listHS = await _context.ChiTietLops.Where(i => listMaLop.Contains(i.LopId) && i.NamHoc == kyhoc.NamHoc).ToListAsync();
                    foreach (var hs in listHS)
                    {
                        var nguoiDungHS = await _context.NguoiDungs.FirstOrDefaultAsync(item => item.Username == hs.Username && item.UserType == 2);
                        listNguoiDung.Add(nguoiDungHS);
                    }

                    listNguoiDung = listNguoiDung.OrderBy(u => u.HoTen.Split()[u.HoTen.Split().Length - 1]).ToList();

                    var vitri = listNguoiDung.FindIndex(i => i.Username == username);
                    var phongthi = vitri / 24;
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
                        PhongThi = phongthi + 1
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
                lstLichThiSangDto = lstLichThiSangDto.OrderBy(u => new TimeOnly(Int32.Parse(u.ThoiGianBatDau.Split(":")[0]), Int32.Parse(u.ThoiGianBatDau.Split(":")[1]))).ToList();
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
