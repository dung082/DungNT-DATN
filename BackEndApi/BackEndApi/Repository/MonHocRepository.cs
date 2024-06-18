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

        public async Task<ActionResult<List<MonHocTheoKhoiDto>>> LayMonHocTheoKhoi(int khoi)
        {
            List<MonHocTheoKhoiDto> listMonHocTheoKhoi = new List<MonHocTheoKhoiDto>();
            if (String.IsNullOrWhiteSpace(khoi.ToString()) || khoi == 0)
            {
                //var khoi = await _context.Khois.FirstOrDefaultAsync(item => item.MaKhoi.ToLower().Contains("K10".ToLower()));
                var listMonHocDefault = await _context.MonHocs.Where(item => item.Khoi == 10).ToListAsync();
                foreach (var monHoc in listMonHocDefault)
                {
                    MonHocTheoKhoiDto monHocTheoKhoiDto = new MonHocTheoKhoiDto()
                    {
                        Id = monHoc.Id,
                        MaMonHoc = monHoc.MaMonHoc,
                        TenMonHoc = monHoc.TenMonHoc,
                        Khoi = khoi,
                        TenHocKy = monHoc.TenHocKy,
                        SoTietHoc = monHoc.SoTietHoc,
                    };
                    listMonHocTheoKhoi.Add(monHocTheoKhoiDto);
                }
                return listMonHocTheoKhoi;
            }
            var listMonHoc = await _context.MonHocs.Where(item => item.Khoi == khoi).ToListAsync();
            foreach (var monHoc in listMonHoc)
            {
                MonHocTheoKhoiDto monHocTheoKhoiDto = new MonHocTheoKhoiDto()
                {
                    Id = monHoc.Id,
                    MaMonHoc = monHoc.MaMonHoc,
                    TenMonHoc = monHoc.TenMonHoc,
                    Khoi = monHoc.Khoi,
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
            if (String.IsNullOrWhiteSpace(monHocDto.Khoi.ToString()))
            {
                throw new Exception("Khối học không được để trống");
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
                Khoi = monHocDto.Khoi,
                SoTietHoc = monHocDto.SoTietHoc,
            };

            _context.MonHocs.Add(monHoc);
            _context.SaveChanges();
            return new JsonResult(monHoc);
        }
    }
}
