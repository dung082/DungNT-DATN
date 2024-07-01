using BackEndApi.Dto;
using Microsoft.AspNetCore.Mvc;

namespace BackEndApi.Repository
{
    public interface IMonThiRepository
    {
        public Task<ActionResult> ThemMonThi(MonThiDTO monThiDTO);
        public Task<ActionResult> LayMonThiTheoLopThi(Guid lopId);
    }
}
