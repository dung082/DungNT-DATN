namespace BackEndApi.Dto
{
    public class DiemTongKetAddDto
    {
        public string Username { get; set; }
        public Guid KyHocId { get; set; }
        public Guid LopId { get; set; }
        public List<DiemAddDto> DiemAdds { get; set; }
    }

    public class DiemTongKetView
    {
        public Guid Id { get; set; }
        public string MaMon { get; set; }
        public string TenMon { get; set; }
        public string Username { get; set; }
        public Guid KyHocId { get; set; }
        public Guid MonTongKetId { get; set; }
        public Guid LopId { get; set; }
        public decimal diem {  get; set; }
    }


    public class DiemTongKetAddDtoResult
    {
        public string Username { get; set; }
        public Guid KyHocId { get; set; }
        public Guid LopId { get; set; }
        public List<DiemAddResultDto> DiemAddsResult { get; set; }
    }

    public class DiemAddDto
    {
        public Guid MonTongKetId { get; set; }
        public decimal Diem { get; set; }
    }

    public class DiemAddResultDto
    {
        public Guid MonTongKetId { get; set; }
        public decimal Diem { get; set; }
        public string Message { get; set; }

    }
}
