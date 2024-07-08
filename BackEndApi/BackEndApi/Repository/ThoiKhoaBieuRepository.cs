using BackEndApi.Dto;
using BackEndApi.Interface.IRepository;
using BackEndData;
using BackEndData.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
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

        public async Task<ActionResult> LayThoiKhoaBieu(DateTime? ngayHoc)
        {
            Dictionary<string, List<ThoiKhoaBieu>> list = new Dictionary<string, List<ThoiKhoaBieu>>();
            DateOnly[] weekDays = new DateOnly[7];
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
                foreach (var item in weekDays)
                {
                    var lsttkb = await _context.ThoiKhoaBieus.Where(item1 => DateOnly.FromDateTime(item1.NgayHoc) == item).ToListAsync();
                    list.Add(item.ToString("dd/MM/yyyy"), lsttkb);
                }
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
                // Thiết lập thứ Hai là ngày đầu tuần
                foreach (var item in weekDays)
                {
                    var lsttkb = await _context.ThoiKhoaBieus.Where(item1 => DateOnly.FromDateTime(item1.NgayHoc) == item).ToListAsync();
                    list.Add(item.ToString("dd/MM/yyyy"), lsttkb);
                }
            }

            return new JsonResult(list);
        }

        public async Task<ActionResult> ThemThoiKhoaBieu(ThoiKhoaBieuDto thoiKhoaBieuDto)
        {
            var tkb = await _context.ThoiKhoaBieus.FirstOrDefaultAsync(item => item.TietHocId == thoiKhoaBieuDto.TietHocId && item.NgayHoc == thoiKhoaBieuDto.NgayHoc);
            if (tkb == null)
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
