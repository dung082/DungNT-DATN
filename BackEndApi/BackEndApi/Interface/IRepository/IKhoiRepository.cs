using BackEndApi.Dto;
using BackEndData.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BackEndApi.Interface.IRepository
{
    public interface IKhoiRepository
    {
        public Task<ActionResult<List<Khoi>>> GetAllKhoi();
        public IActionResult CreateKhoi(KhoiDto khoidto);
        public IActionResult UpdateKhoi(Khoi khoi);
        public IActionResult DeleteKhoi(Guid id);
    }
}
