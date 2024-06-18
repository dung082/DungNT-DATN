using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndData.Entities
{
    public class ChiTietLop
    {
        public Guid Id { get; set; }    
        public Guid LopId { get; set; }
        public string Username { get; set; }
        public string NamHoc{ get; set; }  
    }
}
