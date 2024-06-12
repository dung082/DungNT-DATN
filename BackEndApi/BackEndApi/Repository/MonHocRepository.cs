using BackEndApi.Dto;
using BackEndApi.Interface.IRepository;
using BackEndData;
using BackEndData.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEndApi.Repository
{
    public class MonHocRepository : IMonHocRepository
    {
        private ApplicationDbContext _context;
        public MonHocRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<List<MonHocTheoKhoiDto>>> LayMonHocTheoKhoi(Guid? KhoiId)
        {
            List<MonHocTheoKhoiDto> listMonHocTheoKhoi = new List<MonHocTheoKhoiDto>();
            if (String.IsNullOrWhiteSpace(KhoiId.ToString()))
            {
                var khoi = await _context.Khois.FirstOrDefaultAsync(item => item.MaKhoi.ToLower().Contains("K10".ToLower()));
                var listMonHocDefault = await _context.MonHocs.Where(item => item.KhoiId == khoi.Id).ToListAsync();
                foreach (var monHoc in listMonHocDefault)
                {
                    MonHocTheoKhoiDto monHocTheoKhoiDto = new MonHocTheoKhoiDto()
                    {
                        Id = monHoc.Id,
                        MaMonHoc = monHoc.MaMonHoc,
                        TenMonHoc = monHoc.TenMonHoc,
                        KhoiId = monHoc.KhoiId,
                        TenKhoi = khoi.TenKhoi,
                        TenHocKy = monHoc.TenHocKy,
                        SoTietHoc = monHoc.SoTietHoc,
                    };
                    listMonHocTheoKhoi.Add(monHocTheoKhoiDto);
                }
                return listMonHocTheoKhoi;
            }
            var listMonHoc = await _context.MonHocs.Where(item => item.KhoiId == KhoiId).ToListAsync();
            foreach (var monHoc in listMonHoc)
            {
                var khoi = await _context.Khois.FirstOrDefaultAsync(item => item.Id == monHoc.KhoiId);
                MonHocTheoKhoiDto monHocTheoKhoiDto = new MonHocTheoKhoiDto()
                {
                    Id = monHoc.Id,
                    MaMonHoc = monHoc.MaMonHoc,
                    TenMonHoc = monHoc.TenMonHoc,
                    KhoiId = monHoc.KhoiId,
                    TenKhoi = khoi.TenKhoi,
                    TenHocKy = monHoc.TenHocKy,
                    SoTietHoc = monHoc.SoTietHoc,
                };
                listMonHocTheoKhoi.Add(monHocTheoKhoiDto);
            }
            return listMonHocTheoKhoi;
        }

        public async Task<ActionResult<List<MonHoc>>> LayTatCaMonHoc()
        {
            var listMonHoc = await _context.MonHocs.ToListAsync();
            return listMonHoc;
        }

        public IActionResult ThemMonHoc(MonHocDto monHocDto)
        {
            if (String.IsNullOrWhiteSpace(monHocDto.MaMonHoc))
            {
                throw new Exception("Mã môn học không được để trống");
            }
            if (String.IsNullOrWhiteSpace(monHocDto.TenMonHoc))
            {
                throw new Exception("Tên môn học không được để trống");
            }
            if (String.IsNullOrWhiteSpace(monHocDto.KhoiId.ToString()))
            {
                throw new Exception("Mã khối học không được để trống");
            }
            if (String.IsNullOrWhiteSpace(monHocDto.TenHocKy))
            {
                throw new Exception("Tên kỳ học không được để trống");
            }
            if (monHocDto.SoTietHoc == 0 || String.IsNullOrWhiteSpace(monHocDto.SoTietHoc.ToString()))
            {
                throw new Exception("Số tiết học phải khác 0 và không được để trống");
            }

            MonHoc monHoc = new MonHoc()
            {
                Id = new Guid(),
                MaMonHoc = monHocDto.MaMonHoc,
                TenMonHoc = monHocDto.TenMonHoc,
                TenHocKy = monHocDto.TenHocKy,
                KhoiId = monHocDto.KhoiId,
                SoTietHoc = monHocDto.SoTietHoc,
            };

            _context.MonHocs.Add(monHoc);
            _context.SaveChanges();
            return new JsonResult(monHoc);
        }
    }
}
