namespace BackEndApi.Dto
{
    public class LichThiDto
    {
        public Guid KyThiId { get; set; }
        public DateTime NgayThi { get; set; }
        public Guid CaHocId { get; set; }
        public int KhoiThi { get; set; }
        public string KhoiHoc { get; set; }
        public string ThoiGianBatDau { get; set; }
        public string ThoiGianKetThuc { get; set; }
        public Guid MonThiId { get; set; }
    }
}
