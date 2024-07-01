using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndData.Entities
{
    public class MonThi
    {
        public Guid Id { get; set; }
        public string MaMonThi {  get; set; }
        public string TenMonThi { get; set; }
        public string? KhoiThi {  get; set; }
    }
}
