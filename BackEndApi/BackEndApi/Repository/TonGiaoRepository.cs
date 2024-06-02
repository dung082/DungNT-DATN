using BackEndApi.Dto;
using BackEndApi.Interface.IRepository;
using BackEndData;
using BackEndData.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEndApi.Repository
{
    public class TonGiaoRepository : ITonGiaoRepository
    {
        public ApplicationDbContext _context;
        public TonGiaoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        //public async Task<ActionResult<List<NamHoc>>> LayNamHocTheoKhoaHocId(Guid khoaHocId)
        //{
        //    return await _context.NamHocs.Where(item => item.KhoaHoc == khoaHocId).ToListAsync();
        //}

        public IActionResult ThemTonGiao(TonGiaoDto tonGiaoDto)
        {
            if (String.IsNullOrWhiteSpace(tonGiaoDto.TenTonGiao))
            {
                throw new Exception("Tên tôn giáo không được để trống");
            }

            TonGiao tonGiao = new TonGiao()
            {
                Id = new Guid(),
                TenTonGiao = tonGiaoDto.TenTonGiao,
            };
            _context.TonGiaos.Add(tonGiao);
            _context.SaveChanges();
            return new JsonResult(tonGiao);
        }

        public async Task<ActionResult<List<TonGiao>>> LayToanBoTonGiao()
        {
            return await _context.TonGiaos.ToListAsync();
        }
    }
}
