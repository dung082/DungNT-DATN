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
        public string Email { get; set; }
        public Guid DanTocId { get; set; }
        public string Propeties { get; set; }
    }
}
