using BackEndApi.Interface.IRepository;
using BackEndData;
using BackEndData.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BackEndApi.Repository
{
    public class TaiKhoanRepository : ITaiKhoanRepository
    {
        public ApplicationDbContext _context;
        public TaiKhoanRepository(ApplicationDbContext context) { _context = context; }
        public IActionResult Login(TaiKhoanDto taiKhoanDto)
        {
            var taiKhoan = _context.TaiKhoans.Where(item => item.Username == taiKhoanDto.Username && item.Password == HashPassword(taiKhoanDto.Password)).FirstOrDefault();
            if(taiKhoan == null )
            {
                throw new Exception("Tài khoản hoặc mật khẩu không chính xác");
            }
            
            NguoiDung nguoiDung = new NguoiDung();
            nguoiDung = _context.NguoiDungs.FirstOrDefault(item => item.Username == taiKhoanDto.Username);
            return new JsonResult(nguoiDung);
        }

        string HashPassword(string password)
        {
            if (password == null)
            {
                throw new Exception("Mật khẩu không được để trống");
            }
            byte[] data = System.Text.Encoding.ASCII.GetBytes(password);
            data = System.Security.Cryptography.MD5.Create().ComputeHash(data);
            return Convert.ToBase64String(data);
        }
    }
}
