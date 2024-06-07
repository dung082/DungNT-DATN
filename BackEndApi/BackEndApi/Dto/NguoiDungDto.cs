namespace BackEndApi.Dto
{
    public class NguoiDungDto
    {
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public int GioiTinh { get; set; }
        public int UserType { get; set; }
        public string SoDienThoai { get; set; }
        public Guid? KhoaHocId { get; set; } 
        public Guid DanTocId { get; set; }
        public Guid TonGiaoId { get; set; } 
        public string Propeties { get; set; }
        public string Avatar { get; set; }
        public string? CCCD { get; set; }
        public string? HoTenCha { get; set; }
        public int? NamSinhCha { get; set; }
        public Guid? TonGiaoIdCha { get; set; }
        public Guid? DanTocIdCha { get; set; }
        public string? SoDienThoaiCha { get; set; }
        public string? DiaChiCha { get; set; }
        public string? HoTenMe { get; set; }
        public int? NamSinhMe { get; set; }
        public Guid? TonGiaoIdMe { get; set; }
        public Guid? DanTocIdMe { get; set; }
        public string? SoDienThoaiMe { get; set; }
        public string? DiaChiMe { get; set; }
    }
}
