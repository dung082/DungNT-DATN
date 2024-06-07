using BackEndApi.Dto;
using BackEndData.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BackEndApi.Interface.IRepository
{
    public interface ITietHocRepository
    {
        public Task<ActionResult<List<TietHoc>>> LayToanBoTietHoc();
        public IActionResult ThemTietHoc(TietHocDto tietHocDto);
    }
}
