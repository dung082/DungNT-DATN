using BackEndApi.Dto;
using BackEndApi.Interface.IRepository;
using BackEndData;
using BackEndData.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEndApi.Repository
{
    public class CaHocRepository : ICaHocRepository
    {
        public ApplicationDbContext _context;
        public CaHocRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<List<CaHoc>>> LayToanBoCaHoc()
        {
            return await _context.CaHocs.ToListAsync();
        }

        public IActionResult ThemCaHoc(CaHocDto caHocDto)
        {
            if (String.IsNullOrWhiteSpace(caHocDto.TenCaHoc))
            {
                throw new Exception("Tên ca học không được để trống");
            }
            CaHoc caHoc = new CaHoc()
            {
                Id = new Guid(),
                TenCaHoc = caHocDto.TenCaHoc,
            };

            _context.CaHocs.Add(caHoc);
            _context.SaveChanges();
            return new JsonResult(caHoc);
        }
    }
}
