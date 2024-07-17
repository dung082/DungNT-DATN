using BackEndApi.Dto;
using Microsoft.AspNetCore.Mvc;

namespace BackEndApi.Repository
{
    public interface IMonTongKetRepository
    {
        public Task<ActionResult> ThemMon(MonTongKetDto monTongKetDto);
        public Task<ActionResult> LayDanhSachMon();
    }
}
