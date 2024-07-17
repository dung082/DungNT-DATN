using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndData.Entities
{
    public class DiemTongKet
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public int Khoi { get; set; }
        public Guid KyHoc { get; set; }
        public Guid MonTongKet { get; set; }
        public decimal Diem { get; set; }
    }
}
