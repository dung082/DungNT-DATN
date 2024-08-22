namespace BackEndApi.Dto
{
    public class DiemTongKetAddDto
    {
        public string Username { get; set; }
        public Guid KyHocId { get; set; }
        public Guid LopId { get; set; }
        public List<DiemAddDto> DiemAdds { get; set; }
    }

    public class DiemTongKetView
    {
        public Guid Id { get; set; }
        public string MaMon { get; set; }
        public string TenMon { get; set; }
        public string Username { get; set; }
        public Guid KyHocId { get; set; }
        public Guid MonTongKetId { get; set; }
        public Guid LopId { get; set; }
        public decimal diem { get; set; }
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

    public class DiemTongKetAddList
    {
        public Guid HocKyId { get; set; }
        public Guid LopId { get; set; }
        public Guid MonTongKetId { get; set; }
        public List<DT> listDT { get; set; }
    }

    public class DT
    {
        public string Username { get; set; }
        public decimal Diem { get; set; }
    }
    public class DiemTongKetAddListResponse
    {
        public Guid HocKyId { get; set; }
        public Guid LopId { get; set; }
        public Guid MonTongKetId { get; set; }
        public List<DTRes> listRes { get; set; }
    }
    public class DTRes
    {
        public string Username { get; set; }
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public int GioiTinh { get; set; }
        public decimal Diem { get; set; }
        public string Message { get; set; }
    }

}
