namespace BackEndApi.Dto
{
    public class ChiTietKyThiDto
    {
        public Guid KyThiId { get; set; }
        public int Khoi { get; set; }
        public Guid MonThiId { get; set; }
        public int ThoiGianThi { set; get; }
        public string ThoiGianBatDau { get; set; }
        public string ThoiGianKetThuc { get; set; }
    }
}
