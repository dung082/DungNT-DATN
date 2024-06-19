using BackEndApi.Dto;
using Microsoft.AspNetCore.Mvc;

namespace BackEndApi.Interface.IRepository
{
    public interface IKyThiRepository
    {
        public Task<ActionResult> LayKyThiTheoNamHoc(string? namHoc);
        public Task<ActionResult> ThemKyThi(KyThiDto kyThiDto);
    }
}
