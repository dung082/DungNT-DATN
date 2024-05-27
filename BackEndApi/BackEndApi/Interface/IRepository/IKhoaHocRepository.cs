using BackEndApi.Dto;
using BackEndData.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BackEndApi.Interface.IRepository
{
    public interface IKhoaHocRepository
    {
        public IActionResult ThemKhoaHoc(KhoaHocDto khoaHocDto);
        public Task<ActionResult<List<KhoaHoc>>> LayTatCaKhoaHoc();
    }
}
