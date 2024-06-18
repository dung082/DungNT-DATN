namespace BackEndApi.Dto
{
    public class KyThiDto
    {
        public string TenKyThi { get; set; }
        public Guid KyHocId { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
    }
}
