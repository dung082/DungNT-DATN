namespace BackEndApi.Dto
{
    public class ThoiKhoaBieuDto
    {
        public Guid TietHocId { get; set; }
        public DateTime NgayHoc { get; set; }
        public Guid KyHocId { get; set; }
        public Guid LopId { get; set; }
        public Guid MonHocId { get; set; }
        public Guid GiaoVienId { set; get; }
    }
}
