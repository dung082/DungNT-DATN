using BackEndApi.Dto;
using BackEndApi.Interface.IRepository;
using BackEndData;
using BackEndData.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEndApi.Repository
{
    public class TietHocRepository : ITietHocRepository
    {
        public ApplicationDbContext _context;
        public TietHocRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<List<TietHoc>>> LayToanBoTietHoc()
        {
            return await _context.TietHocs.ToListAsync();
        }


        public IActionResult ThemTietHoc(TietHocDto tietHocDto)
        {
            if (String.IsNullOrWhiteSpace(tietHocDto.TenTietHoc))
            {
                throw new Exception("Tên tiết học không được để trống");
            }
            if (String.IsNullOrWhiteSpace(tietHocDto.CaHocId.ToString()))
            {
                throw new Exception("Mã ca học không được để trống");
            }
            if (String.IsNullOrWhiteSpace(tietHocDto.ThoiGianBatDau.ToString()))
            {
                throw new Exception("Thời gian bắt đầu không được để trống");
            }
            if (String.IsNullOrWhiteSpace(tietHocDto.ThoiGianKetThuc.ToString()))
            {
                throw new Exception("Thời gian kết thúc không được để trống");
            }

            TietHoc tietHoc = new TietHoc()
            {
                Id = new Guid(),
                TenTietHoc = tietHocDto.TenTietHoc,
                CaHocId = tietHocDto.CaHocId,
                ThoiGianBatDau = tietHocDto.ThoiGianBatDau,
                ThoiGianKetThuc = tietHocDto.ThoiGianKetThuc,
            };
            _context.TietHocs.Add(tietHoc);
            _context.SaveChanges(); 
            return new JsonResult(tietHoc);
        }
    }
}
