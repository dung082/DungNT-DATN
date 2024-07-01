using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndData.Entities
{
    public class DiemThi
    {
        public Guid Id { get; set; }
        public Guid KyThiId { get; set; }
        public string Username { get; set; }
        public Guid LopId { get; set; }
        public Guid MonThiId {  get; set; }  
        public decimal Diem {  get; set; }
    }
}
