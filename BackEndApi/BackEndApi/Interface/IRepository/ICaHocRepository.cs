using BackEndApi.Dto;
using BackEndData.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BackEndApi.Interface.IRepository
{
    public interface ICaHocRepository
    {
        public Task<ActionResult<List<CaHoc>>> LayToanBoCaHoc();
        public IActionResult ThemCaHoc(CaHocDto caHocDto);
    }
}
