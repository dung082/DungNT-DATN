using BackEndApi.Dto;
using BackEndApi.Interface.IRepository;
using BackEndData;
using BackEndData.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BackEndApi.Repository
{
    public class NamHocRepository : INamHocRepository
    {
        public ApplicationDbContext _context;
        public NamHocRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult CreateNamHoc(NamHocDto namHocDto)
        {
            if(String.IsNullOrWhiteSpace(namHocDto.NameHoc))
            {
                throw new Exception("Năm học không được để trống");
            }
            if (_context.NamHocs.Any(item => item.NameHoc == namHocDto.NameHoc)) {
                throw new Exception("Năm học đã tồn tại");
            }

            NamHoc namhoc = new NamHoc()
            {
                Id = new Guid(),
                NameHoc = namHocDto.NameHoc,
            };
            _context.NamHocs.Add(namhoc);
            _context.SaveChanges(); 
            return new JsonResult( namhoc);
        }
    }
}
