using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndData.Entities
{
    public class MonTongKet
    {
        public Guid Id { get; set; }
        public string MaMon { get; set; }
        public string TenMon { get; set; }
    }
}
