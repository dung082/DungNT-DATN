using BackEndApi.Dto;
using BackEndData.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BackEndApi.Interface.IRepository
{
    public interface ILopRepository
    {
        public Task<ActionResult<List<Lop>>> LayTatCaLop() ;
        public Task<IActionResult> ThemLop(LopDto lopDto);
        public IActionResult SuaLop(Lop lop);
        public IActionResult XoaLop(Guid id);
    }
}
