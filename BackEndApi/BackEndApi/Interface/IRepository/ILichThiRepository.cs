using BackEndApi.Dto;
using Microsoft.AspNetCore.Mvc;

namespace BackEndApi.Interface.IRepository
{
    public interface ILichThiRepository
    {
        public Task<ActionResult> LayLichThi(DateTime? ngayThi, string username);
        public Task<ActionResult> ThemLichThi(LichThiDto lichThiDto);
        public Task<ActionResult> ChiTietLichThi(Guid lichThiId, string username);
    }
}
