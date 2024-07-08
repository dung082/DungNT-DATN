using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndData.Entities
{
    public class ThoiKhoaBieu
    {
        public Guid Id { get; set; }
        public Guid TietHocId { get; set; }
        public DateTime NgayHoc { get; set; }
        public Guid KyHocId { get; set; }
        public Guid LopId { get; set; }
        public Guid MonHocId { get; set; }
        public Guid GiaoVienId { set; get; }
        public int Status { get; set; }
    }
}
