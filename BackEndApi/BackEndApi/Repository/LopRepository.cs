using BackEndApi.Dto;
using BackEndApi.Interface.IRepository;
using BackEndData;
using BackEndData.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEndApi.Repository
{
    public class LopRepository : ILopRepository
    {
        public ApplicationDbContext _context;
        public LopRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> ThemLop(LopDto lopDto)
        {
            if (_context.Lops.Any(item => item.MaLop == lopDto.MaLop))
            {
                throw new Exception("Mã lớp đã tồn tại");
            }
            if (_context.Lops.Any(item => item.TenLop == lopDto.TenLop))
            {
                throw new Exception("Tên lớp đã tồn tại");
            }
            if (!_context.Khois.Any(item => item.Id == lopDto.IdKhoi))
            {
                throw new Exception("Mã lớp không tồn tại");
            }
            Lop lop = new Lop()
            {
                Id = new Guid(),
                TenLop = lopDto.TenLop,
                MaLop = lopDto.MaLop,
                IdKhoi = lopDto.IdKhoi,
            };

            _context.Lops.Add(lop);
            _context.SaveChanges();

            return new JsonResult(lop);
        }

        public IActionResult XoaLop(Guid id)
        {
            if (string.IsNullOrWhiteSpace(id.ToString()))
            {
                throw new Exception("Không được để trống mã lớp");
            }
            var lop = _context.Lops.FirstOrDefault(item => item.Id == id);
            if (lop == null)
            {
                throw new Exception("Lớp được xóa không tồn tại");
            }
            _context.Lops.Remove(lop);
            _context.SaveChanges();
            return new JsonResult(lop);
        }

        public async Task<ActionResult<List<Lop>>> LayTatCaLop()
        {
            var listLop = await _context.Lops.ToListAsync();
            return listLop;
        }

        public IActionResult SuaLop(Lop lop)
        {
            var lopEx = _context.Lops.FirstOrDefault(item => item.Id == lop.Id);
            if (lopEx == null)
            {
                throw new Exception("Không tồn tại khối ");
            }
            if (String.IsNullOrWhiteSpace(lop.TenLop))
            {
                throw new Exception("Tên lớp không được để trống");
            }
            if (String.IsNullOrWhiteSpace(lop.MaLop))
            {
                throw new Exception("Mã lớp không được để trống");
            }
            if (String.IsNullOrWhiteSpace(lop.IdKhoi.ToString()))
            {
                throw new Exception("Mã khối không được để trống");
            }
            if (_context.Lops.Any(item => item.MaLop == lop.MaLop))
            {
                throw new Exception("Mã lớp đã tồn tại");
            }
            if (_context.Lops.Any(item => item.TenLop == lop.TenLop))
            {
                throw new Exception("Tên lớp đã tồn tại");
            }
            lopEx.MaLop = lop.MaLop;
            lopEx.TenLop = lop.TenLop;
            lopEx.IdKhoi = lop.IdKhoi;
            _context.Lops.Update(lopEx);
            _context.SaveChanges();
            return new JsonResult(lopEx);
        }
    }
}
