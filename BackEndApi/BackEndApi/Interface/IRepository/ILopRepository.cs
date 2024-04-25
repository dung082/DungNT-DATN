using BackEndApi.Dto;
using BackEndData.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BackEndApi.Interface.IRepository
{
    public interface ILopRepository
    {
        public Task<ActionResult<List<Lop>>> GetAllLop() ;
        public Task<IActionResult> CreateLop(LopDto lopDto);
        public IActionResult UpdateLop(Lop lop);
        public IActionResult DeleteLop(Guid id);
    }
}
