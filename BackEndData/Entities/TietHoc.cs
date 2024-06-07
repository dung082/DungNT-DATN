using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndData.Entities
{
    public class TietHoc
    {
        public Guid Id { get; set; }
        public string TenTietHoc {  get; set; }
        public Guid CaHocId { get; set; }
        public TimeOnly ThoiGianBatDau { get; set; }
        public TimeOnly ThoiGianKetThuc { get; set; }
    }
}
