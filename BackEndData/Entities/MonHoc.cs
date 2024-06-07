using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndData.Entities
{
    public class MonHoc
    {
        public Guid Id { get; set; }
        public string MaMonHoc {  get; set; }
        public string TenMonHoc { get; set; }
        public Guid KhoiId { get; set; }
        public string TenHocKy { get; set; }
        public int SoTietHoc { get; set; }
    }
}
