using BackEndApi.Dto;
using BackEndApi.Interface.IRepository;
using BackEndData;
using BackEndData.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEndApi.Repository
{
    public class NamHocRepository : INamHocRepository
    {
        public ApplicationDbContext _context;
        public NamHocRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        //public async Task<ActionResult<List<NamHoc>>> LayNamHocTheoKhoaHocId(Guid khoaHocId)
        //{
        //    return await _context.NamHocs.Where(item => item.KhoaHoc == khoaHocId).ToListAsync();
        //}

        public IActionResult ThemNamHoc(NamHocDto namHocDto)
        {
            if (String.IsNullOrWhiteSpace(namHocDto.NameHoc))
            {
                throw new Exception("Năm học không được để trống");
            }

            NamHoc namhoc = new NamHoc()
            {
                Id = new Guid(),
                NameHoc = namHocDto.NameHoc,
            };
            _context.NamHocs.Add(namhoc);
            _context.SaveChanges();
            return new JsonResult(namhoc);
        }
    }
}
