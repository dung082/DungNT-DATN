using BackEndApi.Dto;
using Microsoft.AspNetCore.Mvc;

namespace BackEndApi.Interface.IRepository
{
    public interface ILichThiRepository
    {
        public Task<ActionResult> LayLichThi();
        public Task<ActionResult> ThemLichThi(LichThiDto lichThiDto);
    }
}
