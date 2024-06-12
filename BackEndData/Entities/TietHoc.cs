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
        public string ThoiGianBatDau { get; set; }
        public string ThoiGianKetThuc { get; set; }
    }
}
