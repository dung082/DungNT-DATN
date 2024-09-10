using BackEndApi.Dto;
using BackEndData.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BackEndApi.Interface.IRepository
{
    public interface IChiTietLopHocRepository
    {
        public IActionResult ThemHocSinhVaoLop(ChiTietLopHocDto chiTietLopHocDto);
        public IActionResult ChuyenLop(ChiTietLopHocDto chiTietLopHocDto);
        public IActionResult XoaHocSinhTrongLop(Guid chiTietLopHocId);
        public Task<ActionResult> LayHocSinhTrongLop(string username);
        public Task<ActionResult> LayHocSinhTrongLopById(string namhoc , Guid lopId);
        public Task<ActionResult> LayHocSinhTrongLopDiemDanhById(string namhoc , Guid lopId);
    }
}
