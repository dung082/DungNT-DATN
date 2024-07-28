using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndData.Entities
{
    public class ThongBao
    {
        public Guid Id { get; set; }  
        public string? Username { get; set; }
        public Guid? LopId { get; set; }
        public string? NamHoc {  get; set; }
        public int Status { get; set; }
        public DateTime? NgayTao { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string? Link { get; set; }
    }
}
