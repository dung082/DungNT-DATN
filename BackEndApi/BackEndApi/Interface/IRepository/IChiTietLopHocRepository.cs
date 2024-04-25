using BackEndApi.Dto;
using Microsoft.AspNetCore.Mvc;

namespace BackEndApi.Interface.IRepository
{
    public interface IChiTietLopHocRepository
    {
        public IActionResult CreateChiTietLopHoc(ChiTietLopHocDto chiTietLopHocDto);
    }
}
