namespace BackEndApi.Dto
{
    public class DiemTongKetAddDto
    {
        public string Username { get; set; }
        public Guid KyHocId { get; set; }
        public Guid LopId { get; set; }
        public List<DiemAddDto> DiemAdds { get; set; }
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
