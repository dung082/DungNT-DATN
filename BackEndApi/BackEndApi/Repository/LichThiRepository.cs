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

        public Task<ActionResult> LayLichThi()
        {
            throw new NotImplementedException();
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
