namespace BackEndApi.Dto
{
    public class DiemTongKetDto
    {
        public string Username { get; set; }
        public Guid KyHocId { get; set; }
        public Guid LopId { get; set; }
        public Guid MonTongKetId { get; set; }
        public decimal Diem { get; set; }
    }
}
