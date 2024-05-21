using BackEndApi.Dto;
using BackEndData.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BackEndApi.Interface.IRepository
{
    public interface INguoiDungRepository
    {
        public Task<ActionResult<List<NguoiDung>>> LayTatCaNguoiDung();
        public Task<ActionResult<List<NguoiDung>>> LayNguoiDungTheoIdLop(Guid idLop);
        public IActionResult ThemNguoiDung(NguoiDungDto nguoiDungDto);
        public IActionResult SuaNguoiDung(NguoiDung nguoiDung);
        public IActionResult XoaNguoiDung(Guid idNguoiDung);
        public Task<ActionResult<NguoiDung>> LayThongTinTaiKhoanDangNhap(string username);

    }
}
