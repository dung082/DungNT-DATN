using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndData.Entities
{
    public class Khoi
    {
        [Key]
        public Guid Id { get; set; }  
        public string MaKhoi {  get; set; }
        public string TenKhoi { get; set; }
    }
}
