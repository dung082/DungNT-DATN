using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndData.Entities
{
    public class ChiTietKyThi
    {
        public Guid Id { get; set; }
        public Guid KyThiId { get; set; }
        public Guid KhoiId { get; set; }
        public Guid MonThiId { get; set; }
        public int ThoiGianThi { set; get; }
        public string ThoiGianBatDau {  get; set; }
        public string ThoiGianKetThuc {  get; set; }
    }
}
