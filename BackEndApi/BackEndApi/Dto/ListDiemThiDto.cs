namespace BackEndApi.Dto
{
    public class ListDiemThiDto
    {
        public Guid KyThiId { get; set; }
        public Guid LopId { get; set; }
        public Guid MonThiId { get; set; }
        public List<DiemThiInListDiemThi> listDiemThi { get; set; }
    }

    public class DiemThiInListDiemThi
    {
        public string username { get; set; }
        public decimal diem { get; set; }
    }

    public class ListDiemThiDtoResponse
    {
        public Guid KyThiId { get; set; }
        public Guid LopId { get; set; }
        public Guid MonThiId { get; set; }
        public List<DiemThiInListDiemThiResponse> listDiemThiResponse { get; set; }
    }

    public class DiemThiInListDiemThiResponse
    {
        public string username { get; set; }
        public string hoTen {  get; set; }
        public DateTime ngaySinh {  get; set; }
        public int gioiTinh {  get; set; }
        public decimal diem { get; set; }
        public string Message { get; set; }
    }
}
