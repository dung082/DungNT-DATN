using BackEndApi.Dto;
using BackEndData.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BackEndApi.Interface.IRepository
{
    public interface IDiemTongKetRepository
    {
        public Task<ActionResult> LayDiemTongKet(string? username, Guid? kyHocId, Guid? monTongKet);
        public Task<ActionResult> ThemDiemTongKet(DiemTongKetDto diemThiDto);
        public Task<ActionResult> LayDiemHocBa(string username, int khoi);
    }
}
