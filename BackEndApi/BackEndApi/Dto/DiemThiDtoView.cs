namespace BackEndApi.Dto
{
    public class DiemThiDtoView
    {
        public Guid Id { get; set; }
        public Guid KyThiId { get; set; }
        public string Username { get; set; }
        public string HoTen { get; set; }
        public string TenMonThi { get; set; }
        public string MaMonThi { get; set; }
        public Guid LopId { get; set; }
        public Guid MonThi { get; set; }
        public decimal Diem { get; set; }
    }
}
