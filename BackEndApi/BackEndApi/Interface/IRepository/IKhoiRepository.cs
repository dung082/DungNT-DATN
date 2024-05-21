using BackEndApi.Dto;
using BackEndData.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BackEndApi.Interface.IRepository
{
    public interface IKhoiRepository
    {
        public Task<ActionResult<List<Khoi>>> LayTatCaKhoi();
        public IActionResult ThemKhoi(KhoiDto khoidto);
        public IActionResult SuaKhoi(Khoi khoi);
        public IActionResult XoaKhoi(Guid id);
    }
}
