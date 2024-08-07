using BackEndApi.Dto;
using BackEndApi.Interface.IRepository;
using BackEndData;
using BackEndData.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEndApi.Repository
{
    public class KyThiRepository : IKyThiRepository
    {
        public ApplicationDbContext _context { get; set; }

        public KyThiRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ActionResult> LayKyThiTheoNamHoc(string? namHoc)
        {
            List<KyHoc> listKyHoc = new List<KyHoc>();
            List<KyThi> listKyThi = new List<KyThi>();
            if (String.IsNullOrWhiteSpace(namHoc))
            {
                string namhoc = "";
                var month = DateTime.Now.Month;
                var year = DateTime.Now.Year;
                if (month >= 10)
                {
                    namhoc = year + "-" + (year + 1);
                }
                else
                {
                    namhoc = (year - 1) + "-" + year;
                }

                listKyHoc = await _context.KyHocs.Where(item => item.NamHoc == namhoc).ToListAsync();
            }
            else
            {
                listKyHoc = await _context.KyHocs.Where(item => item.NamHoc == namHoc).ToListAsync();
            }
            if (listKyHoc.Count == 0)
            {
                throw new Exception("Không có kỳ học nào trong năm");
            }

            foreach (var item in listKyHoc)
            {
                var lstkythi = await _context.KyThis.Where(i => i.KyHocId == item.Id).ToListAsync();
                foreach (var j in lstkythi)
                {
                    listKyThi.Add(j);
                }
            }

            return new JsonResult(listKyThi);
        }

        public async Task<ActionResult> ThemKyThi(KyThiDto kyThiDto)
        {
            if (await _context.KyHocs.FirstOrDefaultAsync(item => item.Id == kyThiDto.KyHocId) == null)
            {
                throw new Exception("Kỳ học không tồn tại");
            }
            KyThi kythi = new KyThi()
            {
                Id = Guid.NewGuid(),
                KyHocId = kyThiDto.KyHocId,
                TenKyThi = kyThiDto.TenKyThi,
                NgayBatDau = kyThiDto.NgayBatDau,
                NgayKetThuc = kyThiDto.NgayKetThuc,
            };
            _context.KyThis.Add(kythi);
            _context.SaveChanges();
            return new JsonResult(kythi);
        }
    }
}
