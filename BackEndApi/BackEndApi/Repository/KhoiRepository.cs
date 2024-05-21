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
        public IActionResult ThemKhoi(KhoiDto khoidto)
        {
            if (_context.Khois != null && _context.Khois.Any(item => item.MaKhoi == khoidto.MaKhoi))
            {
                throw new Exception("Mã khối đã tồn tại");
            }
            if (_context.Khois != null && _context.Khois.Any(item => item.TenKhoi == khoidto.TenKhoi))
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

        public IActionResult XoaKhoi(Guid id)
        {
            if (string.IsNullOrWhiteSpace(id.ToString()))
            {
                throw new Exception("Không được để trống mã khối");
            }
            var khoi = _context.Khois.FirstOrDefault(item => item.Id == id);
            if (khoi == null)
            {
                throw new Exception("Khối được xóa không tồn tại");
            }
            _context.Khois.Remove(khoi);
            _context.SaveChanges();
            return new JsonResult(khoi);
        }

        public async Task<ActionResult<List<Khoi>>> LayTatCaKhoi()
        {
            var listKhoi = await _context.Khois.ToListAsync();
            return listKhoi;
        }

        public IActionResult SuaKhoi(Khoi khoi)
        {
            var khoiEx = _context.Khois.FirstOrDefault(item => item.Id == khoi.Id);
            if(khoiEx == null)
            {
                throw new Exception("Không tồn tại khối ");
            }
            if(String.IsNullOrWhiteSpace(khoi.TenKhoi))
            {
                throw new Exception("Tên khối không được để trống");
            }
            if(String.IsNullOrWhiteSpace(khoi.MaKhoi))
            {
                throw new Exception("Mã khối không được để trống");
            }
            if(_context.Khois.Any(item => item.MaKhoi== khoi.MaKhoi))
            {
                throw new Exception("Mã khối đã tồn tại");
            }
            if (_context.Khois.Any(item => item.TenKhoi == khoi.TenKhoi))
            {
                throw new Exception("Tên khối đã tồn tại");
            }
            khoiEx.MaKhoi = khoi.MaKhoi;
            khoiEx.TenKhoi = khoi.TenKhoi;

            _context.Khois.Update(khoiEx);
            _context.SaveChanges();
            return new JsonResult(khoiEx);
        }
    }
}
