using BackEndApi.Dto;
using Microsoft.AspNetCore.Mvc;

namespace BackEndApi.Interface.IRepository
{
    public interface IDiemThiRepository
    {
        public Task<ActionResult> LayDiemThi(int type, string? username, Guid? kyThiId, Guid? monThiId);
        public Task<ActionResult> ThemDiemThi(DiemThiDto diemThiDto);
    }
}
