namespace BackEndApi.Dto
{
    public class DiemThiDto
    {
        public Guid KyThiId { get; set; }
        public string Username { get; set; }
        public Guid LopId { get; set; }
        public Guid MonThiId { get; set; }
        public decimal Diem { get; set; }
    }
}
