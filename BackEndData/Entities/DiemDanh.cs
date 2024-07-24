using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndData.Entities
{
    public class DiemDanh
    {
        public Guid Id { get; set; }
        public Guid CaHocId { get; set; }
        public string Username { get; set; }
        public DateTime NgayHoc {  get; set; }
        public int TrangThai { get; set; }
        public string? LyDo { get; set; }
    }
}
