using BackEndApi.Dto;
using BackEndData.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BackEndApi.Interface.IRepository
{
    public interface IDiemDanhRepository
    {
        public Task<ActionResult> ThemDiemDanh(DiemDanhDto diemDanhDto);
        public Task<ActionResult> LayDanhSachDiemDanhTheoTuan(DateTime? ngay, string username);
        public Task<ActionResult> ChiTietDiemDanh(Guid diemDanhId);
        //public Task<ActionResult> (Guid diemDanhId);
        public Task<ActionResult> XoaDiemDanh(Guid diemDanhId);
        public Task<ActionResult> SuaDiemDanh(DiemDanh diemDanh);
        public Task<ActionResult> DuyetDiemDanh(Guid diemDanhId);
        public Task<ActionResult> LayLichDiemDanh(int? type);
    }
}
