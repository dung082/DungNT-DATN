using BackEndApi.Dto;
using BackEndApi.Interface.IRepository;
using BackEndData;
using BackEndData.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEndApi.Repository
{
    public class MonThiRepository : IMonThiRepository
    {
        private readonly ApplicationDbContext _context;

        public MonThiRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ActionResult> LayMonThiTheoLopThi(Guid lopId)
        {
            var lop = await _context.Lops.FirstOrDefaultAsync(item => item.Id == lopId);
            if (lop == null)
            {
                throw new Exception("Không có lớp thi");
            }
            var listLop = await _context.MonThis.Where(item => item.KhoiThi == null || item.KhoiThi == lop.KhoiHoc || item.KhoiThi == "").ToListAsync();
            return new JsonResult(listLop);
        }

        public async Task<ActionResult> ThemMonThi(MonThiDTO monThiDTO)
        {
            MonThi monThi = new MonThi()
            {
                Id = Guid.NewGuid(),
                MaMonThi = monThiDTO.MaMonThi,
                TenMonThi = monThiDTO.TenMonThi,
                KhoiThi = monThiDTO.KhoiThi,
            };
            _context.MonThis.Add(monThi);
            _context.SaveChanges();
            return new JsonResult(monThi);
        }
    }
}
