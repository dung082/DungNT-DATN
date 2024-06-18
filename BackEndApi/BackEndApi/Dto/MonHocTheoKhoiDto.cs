namespace BackEndApi.Dto
{
    public class MonHocTheoKhoiDto
    {
        public Guid Id { get; set; }
        public string MaMonHoc { get; set; }
        public string TenMonHoc { get; set; }
        public int Khoi { get; set; }
        public string TenHocKy { get; set; }
        public int SoTietHoc { get; set; }
    }
}
