using BackEndApi.Dto;
using BackEndApi.Interface.IRepository;
using BackEndData;
using BackEndData.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEndApi.Repository
{
    public class KhoiRepository : IKhoiRepository
    {
        public ApplicationDbContext _context;
        public KhoiRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult CreateKhoi(KhoiDto khoidto)
        {
            if (_context.Khois != null  && _context.Khois.Any(item => item.MaKhoi == khoidto.MaKhoi))
            {
                throw new Exception("Mã khối đã tồn tại");
            }
            if (_context.Khois != null &&  _context.Khois.Any(item => item.TenKhoi == khoidto.TenKhoi))
            {
                throw new Exception("Tên khối đã tồn tại");
            }

            Khoi khoi = new Khoi()
            {
                Id = new Guid(),
                TenKhoi = khoidto.TenKhoi,
                MaKhoi = khoidto.MaKhoi,
            };

            _context.Khois.Add(khoi);
            _context.SaveChanges();

            return new JsonResult(khoi);
        }

        public async Task<ActionResult<List<Khoi>>> GetAllKhoi()
        {
            var listKhoi = await _context.Khois.ToListAsync();
            return listKhoi;
        }
    }
}
