using BackEndApi.Dto;
using BackEndApi.Interface.IRepository;
using BackEndData;
using BackEndData.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEndApi.Repository
{
    public class KyHocRepository : IKyHocRepository
    {
        public ApplicationDbContext _context {  get; set; }

        public KyHocRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ActionResult> GetKyHocTheoNamHoc(string? namHoc)
        {
            if (String.IsNullOrWhiteSpace(namHoc))
            {
                string namhoc = "";
                var month = DateTime.Now.Month;
                var year = DateTime.Now.Year;
                if (month >= 8)
                {
                    namhoc = year + "-" + (year + 1);
                }
                else
                {
                    namhoc = (year - 1) + "-" + year;
                }
                var newListKyHoc = await _context.KyHocs.Where(item => item.NamHoc == namhoc).ToListAsync();
                return new JsonResult(newListKyHoc);

            }
            var listKyHoc = await _context.KyHocs.Where(item => item.NamHoc == namHoc).ToListAsync();
            return new JsonResult(listKyHoc);
        }

        public async Task<ActionResult> LayTatCaKyHoc()
        {
            var listKyHoc = await _context.KyHocs.ToListAsync();
            return new JsonResult(listKyHoc);
        }

        public IActionResult ThemKyHoc(KyHocDto kyHocDTO)
        {
            if (String.IsNullOrWhiteSpace(kyHocDTO.TenKyHoc)) {
                throw new Exception("Tên kỳ học không được để trống");
            }
            if (String.IsNullOrWhiteSpace(kyHocDTO.NamHoc))
            {
                throw new Exception("Năm học không được để trống");
            }

            KyHoc kyHoc = new KyHoc()
            {
                Id = Guid.NewGuid(),
                TenKyHoc = kyHocDTO.TenKyHoc,
                NamHoc = kyHocDTO.NamHoc,
                NgayBatDau = kyHocDTO.NgayBatDau,
                NgayKetThuc =  kyHocDTO.NgayKetThuc,
            };

            _context.KyHocs.Add(kyHoc);
            _context.SaveChanges();
            return new JsonResult(kyHoc);
        }

    }
}
