using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndData.Entities
{
    public class Lop
    {
        [Key]
        public Guid Id { get; set; }
        public string MaLop { get; set; }
        public string TenLop { get; set; }
        public int Khoi{ get; set; }
        public string KhoiHoc { get; set; }
    }
}
