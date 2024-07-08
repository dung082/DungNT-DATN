using BackEndApi.Dto;
using BackEndData.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BackEndApi.Interface.IRepository
{
    public interface IThoiKhoaBieuRepository
    {
        public Task<ActionResult> ThemThoiKhoaBieu(ThoiKhoaBieuDto thoiKhoaBieuDto);
        public Task<ActionResult> LayThoiKhoaBieu(DateTime? ngayHoc);
    }
}
