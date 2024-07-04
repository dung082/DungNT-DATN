namespace BackEndApi.Dto
{
    public class ThoiKhoaBieuDto
    {
        public Guid TietHocId { get; set; }
        public DateTime NgayHoc { get; set; }
        public DateTime NamHoc { get; set; }
        public Guid LopId { get; set; }
        public Guid MonHocId { get; set; }
        public Guid GiaoVienId { set; get; }
        public int Status { get; set; }
    }
}
