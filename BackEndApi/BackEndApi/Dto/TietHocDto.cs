namespace BackEndApi.Dto
{
    public class TietHocDto
    {
        public string TenTietHoc { get; set; }
        public Guid CaHocId { get; set; }
        public TimeOnly ThoiGianBatDau { get; set; } = new TimeOnly();
        public TimeOnly ThoiGianKetThuc { get; set; } = new TimeOnly();
    }
}
