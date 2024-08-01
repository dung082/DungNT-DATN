using BackEndApi.Dto;
using BackEndData.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BackEndApi.Interface.IRepository
{
    public interface IThongBaoRepository
    {
        public Task<ActionResult> ThemThongBao(ThongBaoDto thongBaoDto);
        public Task<ActionResult> SuaThongBao(ThongBao thongBao);
        public Task<ActionResult> CapNhatTrangThaiListThongBao(List<Guid> listTbId);
        public Task<ActionResult> XoaThongBao(Guid thongBaoId);
        public Task<ActionResult> CapNhatTrangThaiThongBao(Guid thongBaoId);
        public Task<ActionResult> LayThongBao(string username);
    }
}
