using BackEndApi.Dto;
using Microsoft.AspNetCore.Mvc;

namespace BackEndApi.Interface.IRepository
{
    public interface IChiTietLopHocRepository
    {
        public IActionResult ThemHocSinhVaoLop(ChiTietLopHocDto chiTietLopHocDto);
        public IActionResult ChuyenLop(ChiTietLopHocDto chiTietLopHocDto);
        public IActionResult XoaHocSinhTrongLop(Guid chiTietLopHocId);
    }
}
