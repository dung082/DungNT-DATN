using BackEndApi.Dto;
using BackEndData.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BackEndApi.Interface.IRepository
{
    public interface IDiemTongKetRepository
    {
        public Task<ActionResult> LayDiemTongKet(int type, string? username, Guid? kyHocId, Guid? monTongKet);
        public Task<ActionResult> ThemDiemTongKet(DiemTongKetDto diemThiDto);
        public Task<ActionResult> LayDiemHocBa(string username, int khoi);
        public Task<ActionResult> ThemListDiemTongKet(DiemTongKetAddDto diemTongKetAddDto);
        public Task<ActionResult> ThemListDiemTongKet(DiemTongKetAddList diemTongKetAddList);
        public Task<ActionResult> BaoSaiSotDiemTongKet(string username, string namHoc, Guid hocKyId, List<Guid> listMonTongKetId);
        public Task<ActionResult> SuaDiemTongKet(int type, Guid diemTongKetId, decimal diem);
        public Task<ActionResult> LayDiemTongKetTheoUser(string username, Guid monTongKetId, Guid kyHocId);
    }
}
