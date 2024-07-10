namespace BackEndApi.Dto
{
    public class ThoiKhoaBieuViewDto
    {
        public Guid Id { get; set; }
        public Guid TietHocId { get; set; }
        public string TenTietHoc { get; set; }
        public string TenCaHoc { get; set; }
        public Guid CaHocId { get; set; }
        public DateTime NgayHoc { get; set; }
        public Guid KyHocId { get; set; }
        public string TenKyHoc { get; set; }
        public string NamHoc { get; set; }
        public Guid LopId { get; set; }
        public string TenLop { get; set; }
        public Guid MonHocId { get; set; }
        public string TenMonHoc { get; set; }
        public Guid GiaoVienId { set; get; }
        public string TenGiaoVien { get; set; }
        public int Status { get; set; }
    }
}
