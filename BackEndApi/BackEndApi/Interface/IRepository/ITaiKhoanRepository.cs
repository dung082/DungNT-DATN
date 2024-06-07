using BackEndApi.Dto;
using Microsoft.AspNetCore.Mvc;

namespace BackEndApi.Interface.IRepository
{
    public interface ITaiKhoanRepository
    {
        public IActionResult Login(TaiKhoanDto taiKhoanDto);
    }
}
