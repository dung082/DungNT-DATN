using BackEndApi.Dto;
using BackEndData.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BackEndApi.Interface.IRepository
{
    public interface IMonHocRepository
    {
        public Task<ActionResult<List<MonHoc>>> LayTatCaMonHoc();
        public Task<ActionResult<List<MonHocTheoKhoiDto>>> LayMonHocTheoKhoi(Guid? KhoiId);
        public IActionResult ThemMonHoc(MonHocDto monHocDto);
    }
}
