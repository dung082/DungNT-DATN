using BackEndApi.Dto;
using Microsoft.AspNetCore.Mvc;

namespace BackEndApi.Interface.IRepository
{
    public interface IDiemThiRepository
    {
        public Task<ActionResult> LayDiemThi(int type, string? username, Guid? kyThiId, Guid? monThiId);
        public Task<ActionResult> ThemDiemThi(DiemThiDto diemThiDto);
        public Task<ActionResult> ThemListDiemThi(ListDiemThiDto listDiemThiDto);
        public Task<ActionResult> PhucKhaoDiemThi(string username, string namHoc, Guid kyThiId, List<Guid> listMonThiId);
        public Task<ActionResult> SuaDiemThi(int type , Guid diemThiId,decimal diem);
        public Task<ActionResult> LayDiemThiTheoUser(string username, Guid monThiId, Guid kyThiId);
    }
}
