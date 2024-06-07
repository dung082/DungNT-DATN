using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndData.Entities
{
    public class ThoiKhoaBieu
    {
        public int Id { get; set; }
        public Guid TietHocId { get; set; }
        public DateTime NgayHoc {  get; set; }
        public DateTime NamHoc { get; set; }
        public Guid LopId { get; set; } 
        public Guid MonHocId { get; set; }
        public Guid GiaoVienId { set; get; }
    }
}
