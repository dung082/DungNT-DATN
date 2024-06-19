using BackEndApi.Dto;
using Microsoft.AspNetCore.Mvc;

namespace BackEndApi.Interface.IRepository
{
    public interface IKyHocRepository
    {
        public Task<ActionResult> LayTatCaKyHoc();
        public Task<ActionResult> GetKyHocTheoNamHoc(string? namHoc);
        public IActionResult ThemKyHoc(KyHocDto kyHocDto);
    }
}
