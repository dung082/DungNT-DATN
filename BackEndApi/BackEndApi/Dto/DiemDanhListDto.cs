namespace BackEndApi.Dto
{
    public class DiemDanhListDto
    {
        public Guid CaHocId { get; set; }
        public DateTime NgayHoc { get; set; }
        public List<DiemDanhHocSinh> lstDiemDanhHS { get; set; }
    }

    public class DiemDanhHocSinh
    {
        public string Username { get; set; }
        public int TrangThai { get; set; }
        public string? LyDo { get; set; }

    }

    public class DiemDanhListView
    {
        public Guid Id { get; set; }
        public string Username { set; get; }
        public int TrangThai { set; get; }
        public DateTime NgaySinh { get; set; }
        public int GioiTinh { get; set; }
        public string HoTen { set; get; }
        public string LyDo {  set; get; }
    }
}
