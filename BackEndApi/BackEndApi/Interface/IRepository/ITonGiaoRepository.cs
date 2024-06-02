using BackEndApi.Dto;
using BackEndData.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BackEndApi.Interface.IRepository
{
    public interface ITonGiaoRepository
    {
        public IActionResult ThemTonGiao(TonGiaoDto tonGiaoDto);
        public Task<ActionResult<List<TonGiao>>> LayToanBoTonGiao();
        //public Task<ActionResult<List<NamHoc>>> LayNamHocTheoKhoaHocId(Guid khoaHocId);
    }
}
