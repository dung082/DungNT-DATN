using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndData.Entities
{
    public class NguoiDung
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public int Status { get; set; }
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public int GioiTinh { get; set; }
        public int UserType { get; set; }
        public string SoDienThoai { get; set; }
        public string? Email { get; set; }
        public Guid DanTocId { get; set; }
        public string? KhoaHoc { get; set; }
        public string? Propeties { get; set; }
        public string? Avatar { get; set; }
    }
}
