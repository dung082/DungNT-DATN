namespace BackEndApi.Dto
{
    public class DiemDanhDto
    {
        public string Username { get; set; }
        public Guid CaHocId { get; set; }
        public DateTime NgayHoc { get; set; }
        public int TrangThai { get; set; }
        public string? LyDo { get; set; }
    }
}
