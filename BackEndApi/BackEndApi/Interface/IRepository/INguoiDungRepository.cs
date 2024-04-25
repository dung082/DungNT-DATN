using BackEndApi.Dto;
using BackEndData.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BackEndApi.Interface.IRepository
{
    public interface INguoiDungRepository
    {
        public Task<ActionResult<List<NguoiDung>>> GetAllNguoiDung();
        public Task<ActionResult<List<NguoiDung>>> GetNguoiDungByIdLop(Guid idLop);
        public IActionResult CreateNguoiDung(NguoiDungDto nguoiDungDto);
        public IActionResult UpdateNguoiDung(NguoiDung nguoiDung);
        public IActionResult DeleteNguoiDung(Guid idNguoiDung);
    }
}
