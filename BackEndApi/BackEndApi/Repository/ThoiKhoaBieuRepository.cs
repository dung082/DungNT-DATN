using BackEndApi.Dto;
using BackEndApi.Interface.IRepository;
using BackEndData;
using BackEndData.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace BackEndApi.Repository
{
    public class ThoiKhoaBieuRepository : IThoiKhoaBieuRepository
    {
        private readonly ApplicationDbContext _context;

        public ThoiKhoaBieuRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ActionResult> ChiTietThoiKhoaBieu(Guid tkbId)
        {
            var tkb = await _context.ThoiKhoaBieus.FirstOrDefaultAsync(item => item.Id == tkbId);
            if (tkb == null)
            {
                throw new Exception("Lịch học không tồn tại");
            }
            var lop = await _context.Lops.FirstOrDefaultAsync(item => item.Id == tkb.LopId);
            var tiethoc = await _context.TietHocs.FirstOrDefaultAsync(item => item.Id == tkb.TietHocId);
            var cahoc = await _context.CaHocs.FirstOrDefaultAsync(item => item.Id == tiethoc.CaHocId);
            var kyhoc = await _context.KyHocs.FirstOrDefaultAsync(item => item.Id == tkb.KyHocId);
            var monhoc = await _context.MonHocs.FirstOrDefaultAsync(item => item.Id == tkb.MonHocId);
            var gv = await _context.NguoiDungs.FirstOrDefaultAsync(item => item.Id == tkb.GiaoVienId);
            ChiTietThoiKhoaBieuDto thoiKhoaBieuView = new ChiTietThoiKhoaBieuDto()
            {
                Id = tkb.Id,
                GiaoVienId = tkb.GiaoVienId,
                CaHocId = cahoc.Id,
                KyHocId = tkb.KyHocId,
                LopId = tkb.LopId,
                MonHocId = tkb.MonHocId,
                NamHoc = kyhoc.NamHoc,
                NgayHoc = tkb.NgayHoc,
                Status = tkb.Status,
                TenCaHoc = cahoc.TenCaHoc,
                TenGiaoVien = gv.HoTen,
                TenKyHoc = kyhoc.TenKyHoc,
                TenLop = lop.TenLop,
                TenMonHoc = monhoc.TenMonHoc,
                TenTietHoc = tiethoc.TenTietHoc,
                TietHocId = tkb.TietHocId,
                EmailGiaoVien = gv.Email,
                SoDienThoaiGiaoVien = gv.SoDienThoai
            };

            var ctl = await _context.ChiTietLops.Where(item => item.LopId == tkb.LopId && item.NamHoc == kyhoc.NamHoc).ToListAsync();
            List<NguoiDung> listNguoiDung = new List<NguoiDung>();
            foreach (var item in ctl)
            {
                var nd = await _context.NguoiDungs.FirstOrDefaultAsync(item1 => item1.Username == item.Username);
                listNguoiDung.Add(nd);
            };
            listNguoiDung = listNguoiDung.OrderBy(u => u.HoTen.Split()[u.HoTen.Split().Length - 1]).ToList();
            var result = new
            {
                cttkb = thoiKhoaBieuView,
                lstnd = listNguoiDung,
            };
            return new JsonResult(result);
        }

        public async Task<ActionResult> LayThoiKhoaBieu(int type, DateTime? ngayHoc, string username)
        {
            Dictionary<string, List<List<ThoiKhoaBieuViewDto>>> list = new Dictionary<string, List<List<ThoiKhoaBieuViewDto>>>();
            List<List<ThoiKhoaBieuViewDto>> listtkbViewSang = new List<List<ThoiKhoaBieuViewDto>>();
            List<List<ThoiKhoaBieuViewDto>> listtkbViewChieu = new List<List<ThoiKhoaBieuViewDto>>();
            List<ThoiKhoaBieuViewDto> listTkbNgay = new List<ThoiKhoaBieuViewDto>();
            DateOnly[] weekDays = new DateOnly[7];
            string namhoc = "";
            var ngayhoc = new DateTime();
            KyHoc kyHoc = new KyHoc();
            if (type == 0)
            {
                if (String.IsNullOrWhiteSpace(ngayHoc.ToString()))
                {
                    ngayhoc = new DateTime();
                    if (ngayhoc.Month >= 8)
                    {
                        namhoc = ngayhoc.Year.ToString() + "-" + (ngayhoc.Year + 1).ToString();
                    }
                    else
                    {
                        namhoc = (ngayhoc.Year - 1).ToString() + "-" + ngayhoc.Year.ToString();
                    }
                }
                else
                {
                    //ngayhoc = new DateTime
                    ngayhoc = ngayHoc.Value;
                    if (ngayhoc.Month >= 8)
                    {
                        namhoc = ngayhoc.Year.ToString() + "-" + (ngayhoc.Year + 1).ToString();
                    }
                    else
                    {
                        namhoc = (ngayhoc.Year - 1).ToString() + "-" + ngayhoc.Year.ToString();
                    }
                }

                var chitietLop = await _context.ChiTietLops.FirstOrDefaultAsync(item => item.NamHoc == namhoc && item.Username == username);
                var lopHt = await _context.Lops.FirstOrDefaultAsync(item => item.Id == chitietLop.LopId);
                var thoiKhoaBieu = await _context.ThoiKhoaBieus.Where(i => i.LopId == lopHt.Id && DateOnly.FromDateTime(i.NgayHoc) == DateOnly.FromDateTime(ngayhoc)).ToListAsync();
                kyHoc = await _context.KyHocs.FirstOrDefaultAsync(item => DateOnly.FromDateTime(item.NgayBatDau) < DateOnly.FromDateTime(ngayhoc) && DateOnly.FromDateTime(item.NgayKetThuc) > DateOnly.FromDateTime(ngayhoc));

                foreach (var tkb in thoiKhoaBieu)
                {
                    var lop = await _context.Lops.FirstOrDefaultAsync(item => item.Id == tkb.LopId);
                    var tiethoc = await _context.TietHocs.FirstOrDefaultAsync(item => item.Id == tkb.TietHocId);
                    var cahoc = await _context.CaHocs.FirstOrDefaultAsync(item => item.Id == tiethoc.CaHocId);
                    var kyhoc = await _context.KyHocs.FirstOrDefaultAsync(item => item.Id == tkb.KyHocId);
                    var monhoc = await _context.MonHocs.FirstOrDefaultAsync(item => item.Id == tkb.MonHocId);
                    var gv = await _context.NguoiDungs.FirstOrDefaultAsync(item => item.Id == tkb.GiaoVienId);

                    ThoiKhoaBieuViewDto thoiKhoaBieuView = new ThoiKhoaBieuViewDto()
                    {
                        Id = tkb.Id,
                        GiaoVienId = tkb.GiaoVienId,
                        CaHocId = cahoc.Id,
                        KyHocId = tkb.KyHocId,
                        LopId = tkb.LopId,
                        MonHocId = tkb.MonHocId,
                        NamHoc = kyhoc.NamHoc,
                        NgayHoc = tkb.NgayHoc,
                        Status = tkb.Status,
                        TenCaHoc = cahoc.TenCaHoc,
                        TenGiaoVien = gv.HoTen,
                        TenKyHoc = kyhoc.TenKyHoc,
                        TenLop = lop.TenLop,
                        TenMonHoc = monhoc.TenMonHoc,
                        TenTietHoc = tiethoc.TenTietHoc,
                        TietHocId = tkb.TietHocId
                    };

                    listTkbNgay.Add(thoiKhoaBieuView);
                }

                listTkbNgay = listTkbNgay.OrderBy(u => u.TenTietHoc).ToList();

                var result = new
                {
                    ngay = ngayhoc,
                    data = listTkbNgay,
                    lopObj = lopHt,
                    namHoc = namhoc,
                    kyhoc = kyHoc
                };

                return new JsonResult(result);
            }
            else
            {

                if (String.IsNullOrWhiteSpace(ngayHoc.ToString()))
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

                    kyHoc = await _context.KyHocs.FirstOrDefaultAsync(item => DateOnly.FromDateTime(item.NgayBatDau) < weekDays[0] && DateOnly.FromDateTime(item.NgayKetThuc) > weekDays[0]);

                }
                else
                {
                    DateTime date = ngayHoc.Value;
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
                    kyHoc = await _context.KyHocs.FirstOrDefaultAsync(item => DateOnly.FromDateTime(item.NgayBatDau) < weekDays[0] && DateOnly.FromDateTime(item.NgayKetThuc) > weekDays[0]);

                    // Thiết lập thứ Hai là ngày đầu tuần
                }

                var IdCaSang = await _context.CaHocs.Where(item => item.TenCaHoc.Trim().ToLower() == "Ca sáng".ToLower()).Select(i => i.Id).FirstOrDefaultAsync();
                var IdCaChieu = await _context.CaHocs.FirstOrDefaultAsync(item => item.TenCaHoc.Trim().ToLower() == "Ca sáng".ToLower());
                var listTietHocSang = await _context.TietHocs.Where(item => item.CaHocId == IdCaSang).Select(i => i.Id).ToListAsync();
                var lopId = await _context.ChiTietLops.Where(item => item.Username == username && item.NamHoc == namhoc).Select(i => i.LopId).FirstOrDefaultAsync();
                foreach (var item in weekDays)
                {
                    var lsttkb = await _context.ThoiKhoaBieus.Where(item1 => DateOnly.FromDateTime(item1.NgayHoc) == item && item1.LopId == lopId).ToListAsync();
                    List<ThoiKhoaBieuViewDto> lstTkbViewDtoSang = new List<ThoiKhoaBieuViewDto>();
                    List<ThoiKhoaBieuViewDto> lstTkbViewDtoChieu = new List<ThoiKhoaBieuViewDto>();
                    foreach (var tkb in lsttkb)
                    {
                        var lop = await _context.Lops.FirstOrDefaultAsync(item => item.Id == tkb.LopId);
                        var tiethoc = await _context.TietHocs.FirstOrDefaultAsync(item => item.Id == tkb.TietHocId);
                        var cahoc = await _context.CaHocs.FirstOrDefaultAsync(item => item.Id == tiethoc.CaHocId);
                        var kyhoc = await _context.KyHocs.FirstOrDefaultAsync(item => item.Id == tkb.KyHocId);
                        var monhoc = await _context.MonHocs.FirstOrDefaultAsync(item => item.Id == tkb.MonHocId);
                        var gv = await _context.NguoiDungs.FirstOrDefaultAsync(item => item.Id == tkb.GiaoVienId);

                        ThoiKhoaBieuViewDto thoiKhoaBieuView = new ThoiKhoaBieuViewDto()
                        {
                            Id = tkb.Id,
                            GiaoVienId = tkb.GiaoVienId,
                            CaHocId = cahoc.Id,
                            KyHocId = tkb.KyHocId,
                            LopId = tkb.LopId,
                            MonHocId = tkb.MonHocId,
                            NamHoc = kyhoc.NamHoc,
                            NgayHoc = tkb.NgayHoc,
                            Status = tkb.Status,
                            TenCaHoc = cahoc.TenCaHoc,
                            TenGiaoVien = gv.HoTen,
                            TenKyHoc = kyhoc.TenKyHoc,
                            TenLop = lop.TenLop,
                            TenMonHoc = monhoc.TenMonHoc,
                            TenTietHoc = tiethoc.TenTietHoc,
                            TietHocId = tkb.TietHocId
                        };

                        if (listTietHocSang.Contains(tkb.TietHocId))
                        {
                            lstTkbViewDtoSang.Add(thoiKhoaBieuView);

                        }
                        else
                        {
                            lstTkbViewDtoChieu.Add(thoiKhoaBieuView);
                        }
                    }
                    lstTkbViewDtoSang = lstTkbViewDtoSang.OrderBy(u => u.TenTietHoc).ToList();
                    lstTkbViewDtoChieu = lstTkbViewDtoChieu.OrderBy(u => u.TenTietHoc).ToList();
                    listtkbViewSang.Add(lstTkbViewDtoSang);
                    listtkbViewChieu.Add(lstTkbViewDtoChieu);
                }

                list.Add("S", listtkbViewSang);
                list.Add("C", listtkbViewChieu);

                var lopHt = await _context.Lops.FirstOrDefaultAsync(item => item.Id == lopId);
                var result = new
                {
                    ngay = weekDays,
                    data = list,
                    lopObj = lopHt,
                    namHoc = namhoc,
                    kyhoc = kyHoc
                };

                return new JsonResult(result);
            }
            return new JsonResult(true);
        }

        public async Task<ActionResult> ThemListThoiKhoaBieu(List<ThoiKhoaBieuDto> listThoiKhoaBieuDto)
        {
            foreach (var tkbDto in listThoiKhoaBieuDto)
            {
                var tkb = await _context.ThoiKhoaBieus.FirstOrDefaultAsync(item => item.TietHocId == tkbDto.TietHocId && item.NgayHoc == tkbDto.NgayHoc);
                if (tkb != null)
                {
                    throw new Exception("Tiết học trong ngày đã có lịch học");
                }
                var kyhoc = await _context.KyHocs.FirstOrDefaultAsync(item => item.Id == tkbDto.KyHocId);
                if (kyhoc == null)
                {
                    throw new Exception("Kỳ học không tồn tại");
                }
                if (DateOnly.FromDateTime(tkbDto.NgayHoc) < DateOnly.FromDateTime(kyhoc.NgayBatDau) || DateOnly.FromDateTime(tkbDto.NgayHoc) > DateOnly.FromDateTime(kyhoc.NgayKetThuc))
                {
                    throw new Exception("Ngày học không có trong kỳ học ");
                }

                ThoiKhoaBieu thoiKhoaBieu = new ThoiKhoaBieu()
                {
                    Id = Guid.NewGuid(),
                    TietHocId = tkbDto.TietHocId,
                    GiaoVienId = tkbDto.GiaoVienId,
                    KyHocId = tkbDto.KyHocId,
                    LopId = tkbDto.LopId,
                    MonHocId = tkbDto.MonHocId,
                    NgayHoc = tkbDto.NgayHoc,
                    Status = 1
                };

                _context.ThoiKhoaBieus.Add(thoiKhoaBieu);
            }
            _context.SaveChanges();
            return new JsonResult(listThoiKhoaBieuDto);
        }

        public async Task<ActionResult> ThemThoiKhoaBieu(ThoiKhoaBieuDto thoiKhoaBieuDto)
        {
            var tkb = await _context.ThoiKhoaBieus.FirstOrDefaultAsync(item => item.TietHocId == thoiKhoaBieuDto.TietHocId && item.NgayHoc == thoiKhoaBieuDto.NgayHoc);
            if (tkb != null)
            {
                throw new Exception("Tiết học trong ngày đã có lịch học");
            }
            var kyhoc = await _context.KyHocs.FirstOrDefaultAsync(item => item.Id == thoiKhoaBieuDto.KyHocId);
            if (kyhoc == null)
            {
                throw new Exception("Kỳ học không tồn tại");
            }
            if (DateOnly.FromDateTime(thoiKhoaBieuDto.NgayHoc) < DateOnly.FromDateTime(kyhoc.NgayBatDau) || DateOnly.FromDateTime(thoiKhoaBieuDto.NgayHoc) > DateOnly.FromDateTime(kyhoc.NgayKetThuc))
            {
                throw new Exception("Ngày học không có trong kỳ học ");
            }

            ThoiKhoaBieu thoiKhoaBieu = new ThoiKhoaBieu()
            {
                Id = Guid.NewGuid(),
                TietHocId = thoiKhoaBieuDto.TietHocId,
                GiaoVienId = thoiKhoaBieuDto.GiaoVienId,
                KyHocId = thoiKhoaBieuDto.KyHocId,
                LopId = thoiKhoaBieuDto.LopId,
                MonHocId = thoiKhoaBieuDto.MonHocId,
                NgayHoc = thoiKhoaBieuDto.NgayHoc,
                Status = 1
            };

            _context.ThoiKhoaBieus.Add(thoiKhoaBieu);
            _context.SaveChanges();
            return new JsonResult(thoiKhoaBieu);
        }
    }
}
