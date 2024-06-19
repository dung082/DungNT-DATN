using BackEndApi.Dto;
using Microsoft.AspNetCore.Mvc;

namespace BackEndApi.Interface.IRepository
{
    public interface IHocBaRepository
    {
        public Task<ActionResult> GetHocBaByUserName(string userName , int lop);
        public IActionResult ThemDiemHocBa(HocBaDto hocBaDto);
    }

}
