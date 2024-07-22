using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndData.Entities
{
    public class LichThi
    {
        public Guid Id { get; set; }
        public Guid KyThiId { get; set; }
        public Guid CaHocId { get; set; }
        public int KhoiThi{ get; set; }
        public string? KhoiHoc{ get; set; }
        public DateTime NgayThi { get; set; }
        public string ThoiGianBatDau { get; set; }
        public string ThoiGianKetThuc { get; set; }
        public Guid MonThiId { get; set; }

    }
}
