using BackEndApi.Dto;
using BackEndData.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BackEndApi.Interface.IRepository
{
    public interface INamHocRepository
    {
        public IActionResult ThemNamHoc(NamHocDto namHocDto);
        //public Task<ActionResult<List<NamHoc>>> LayNamHocTheoKhoaHocId(Guid khoaHocId);
    }
}
