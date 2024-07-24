using BackEndApi.Dto;
using Microsoft.AspNetCore.Mvc;

namespace BackEndApi.Interface.IRepository
{
    public interface IDiemDanhRepository
    {
        public Task<ActionResult> ThemDiemDanh(DiemDanhDto diemDanhDto);
        public Task<ActionResult> LayDanhSachDiemDanhTheoTuan(DateTime? ngay, string username);
    }
}
