using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndData.Entities
{
    public class KyHoc
    {
        public Guid Id { get; set; }
        public Guid NamHocId { get; set; }
        public string TenKyHoc { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc {  get; set; }
    }
}
