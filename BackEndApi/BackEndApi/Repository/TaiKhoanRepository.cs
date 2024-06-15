using BackEndApi.Dto;
using BackEndApi.Interface.IRepository;
using BackEndData;
using BackEndData.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEndApi.Repository
{
    public class TaiKhoanRepository : ITaiKhoanRepository
    {
        public ApplicationDbContext _context;
        public INguoiDungRepository _inguoiDungRepository;
        public TaiKhoanRepository(ApplicationDbContext context, INguoiDungRepository iNguoiDungRepository)
        {
            _context = context;
            _inguoiDungRepository = iNguoiDungRepository;
        }
        public async Task<ActionResult> Login(TaiKhoanDto taiKhoanDto)
        {
            var taiKhoan = _context.TaiKhoans.Where(item => item.Username == taiKhoanDto.Username && item.Password == HashPassword(taiKhoanDto.Password)).FirstOrDefault();
            if (taiKhoan == null)
            {
                throw new Exception("Tài khoản hoặc mật khẩu không chính xác");
            }

            NguoiDung nguoiDung = new NguoiDung();
            nguoiDung = await _context.NguoiDungs.FirstOrDefaultAsync(item => item.Username == taiKhoanDto.Username);
            var nguoiDungDto = await _inguoiDungRepository.LayThongTinNguoiDung(nguoiDung.Id);
            return new JsonResult(nguoiDungDto);
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
