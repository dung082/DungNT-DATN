using BackEndApi.Dto;
using BackEndData.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BackEndApi.Interface.IRepository
{
    public interface IDantocRepository
    {
        public Task<ActionResult<List<DanToc>>> GetAllDanToc();
        public IActionResult CreateDanToc(DanTocDto dantocDto);
        public IActionResult UpdateDanToc(DanToc dantoc);
        public IActionResult DeleteDanToc(Guid id);
    }
}
