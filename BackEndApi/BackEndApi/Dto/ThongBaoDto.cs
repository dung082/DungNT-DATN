namespace BackEndApi.Dto
{
    public class ThongBaoDto
    {
        public string? Username { get; set; }
        public Guid? LopId { get; set; }
        public string? NamHoc { get; set; }
        public int Status { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string? Link { get; set; }
    }
}
