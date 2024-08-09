namespace BackEndApi.Dto
{
    public class DiemDanhView
    {
        public Guid Id { get; set; }
        public Guid CaHocId { get; set; }
        public string Username { get; set; }
        public string HoTen {  get; set; }
        public DateTime NgayHoc { get; set; }
        public int TrangThai { get; set; }
        public string? LyDo { get; set; }
    }
}
