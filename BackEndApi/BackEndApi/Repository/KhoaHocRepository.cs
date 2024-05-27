using BackEndApi.Dto;
using BackEndApi.Interface.IRepository;
using BackEndData;
using BackEndData.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEndApi.Repository
{
    public class KhoaHocRepository : IKhoaHocRepository
    {
        public ApplicationDbContext _context;
        public KhoaHocRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<List<KhoaHoc>>> LayTatCaKhoaHoc()
        {
            return await _context.KhoaHocs.ToListAsync();
        }

        public IActionResult ThemKhoaHoc(KhoaHocDto khoaHocDto)
        {
            if (String.IsNullOrWhiteSpace(khoaHocDto.TenKhoaHoc))
            {
                throw new Exception("Khóa học không được để trống");
            }
            if (_context.NamHocs.Any(item => item.NameHoc == khoaHocDto.TenKhoaHoc))
            {
                throw new Exception("Khóa học đã tồn tại");
            }

            KhoaHoc khoaHoc = new KhoaHoc()
            {
                Id = new Guid(),
                TenKhoaHoc = khoaHocDto.TenKhoaHoc,
            };
            _context.KhoaHocs.Add(khoaHoc);
            _context.SaveChanges();
            return new JsonResult(khoaHoc);
        }
    }
}
