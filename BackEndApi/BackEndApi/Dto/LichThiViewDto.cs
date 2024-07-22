namespace BackEndApi.Dto
{
    public class LichThiViewDto
    {
        public Guid Id { get; set; }
        public Guid KyThiId { get; set; }
        public string TenKyThi { get; set; }
        public string TenCaHoc { get; set; }
        public string TenMonThi { get; set; }
        public Guid CaHocId { get; set; }
        public int KhoiThi { get; set; }
        public string? KhoiHoc { get; set; }
        public DateTime NgayThi { get; set; }
        public string ThoiGianBatDau { get; set; }
        public string ThoiGianKetThuc { get; set; }
        public Guid MonThiId { get; set; }
    }
}
