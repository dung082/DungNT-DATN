using BackEndApi.Dto;
using BackEndApi.Interface.IRepository;
using BackEndData;
using BackEndData.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEndApi.Repository
{
    public class MonTongKetRepository : IMonTongKetRepository
    {
        private readonly ApplicationDbContext _context;

        public MonTongKetRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ActionResult> LayDanhSachMon()
        {
            var listLop = await _context.MonTongKets.ToListAsync();
            return new JsonResult(listLop);
        }


        public async Task<ActionResult> ThemMon(MonTongKetDto monTongKetDto)
        {
            MonTongKet monThiTK = new MonTongKet()
            {
                Id = Guid.NewGuid(),
                MaMon = monTongKetDto.MaMon,
                TenMon = monTongKetDto.TenMon,
            };
            _context.MonTongKets.Add(monThiTK);
            _context.SaveChanges();
            return new JsonResult(monTongKetDto);
        }
    }
}
