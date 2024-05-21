using BackEndApi.Dto;
using BackEndData.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BackEndApi.Interface.IRepository
{
    public interface IDantocRepository
    {
        public Task<ActionResult<List<DanToc>>> LayToanBoDanToc();
        public IActionResult ThemDanToc(DanTocDto dantocDto);
        public IActionResult SuaDanToc(DanToc dantoc);
        public IActionResult XoaDanToc(Guid id);
    }
}
