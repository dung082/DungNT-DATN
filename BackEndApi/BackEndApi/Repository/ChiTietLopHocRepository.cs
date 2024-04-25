using BackEndApi.Dto;
using BackEndApi.Interface.IRepository;
using BackEndData;
using BackEndData.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BackEndApi.Repository
{
    public class ChiTietLopHocRepository : IChiTietLopHocRepository
    {
        public ApplicationDbContext _context;
        public ChiTietLopHocRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult CreateChiTietLopHoc(ChiTietLopHocDto chiTietLopHocDto)
        {
            if (String.IsNullOrWhiteSpace(chiTietLopHocDto.LopId.ToString()))
            {
                throw new Exception("Mã lớp không được để trống");
            }
            if (String.IsNullOrWhiteSpace(chiTietLopHocDto.Username))
            {
                throw new Exception("Tên tài khoản không được để trống");
            }
            if (String.IsNullOrWhiteSpace(chiTietLopHocDto.NamHocId.ToString()))
            {
                throw new Exception("Mã năm học không được để trống");
            }
            if(!_context.Lops.Any(item => item.Id == chiTietLopHocDto.LopId))
            {
                throw new Exception("Không tồn tại mã lớp");
            }
            if (!_context.NguoiDungs.Any(item => item.Username == chiTietLopHocDto.Username))
            {
                throw new Exception("Không tồn tại tên tài khoản");
            }
            if (!_context.NamHocs.Any(item => item.Id == chiTietLopHocDto.NamHocId))
            {
                throw new Exception("Không tồn tại mã năm học");
            }
            if(_context.ChiTietLops.Any(item => item.LopId == chiTietLopHocDto.LopId && item.Username == chiTietLopHocDto.Username && item.NamHocId == chiTietLopHocDto.NamHocId))
            {
                throw new Exception("Học sinh đã có ở trong lớp");
            }

            ChiTietLop ctl = new ChiTietLop()
            {
                Id = new Guid(),
                LopId = chiTietLopHocDto.LopId,
                Username = chiTietLopHocDto.Username,
                NamHocId = chiTietLopHocDto.NamHocId,
            };
            _context.ChiTietLops.Add(ctl);
            _context.SaveChanges();
            return new JsonResult("Thêm học sinh vào lớp thành công");
        }
    }
}
