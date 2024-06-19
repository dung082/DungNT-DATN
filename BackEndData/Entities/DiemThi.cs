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
        public decimal diemMonToan { get; set; }
        public decimal diemMonVan { get; set; }
        public decimal diemNgoaiNgu { get; set; }
        public decimal diemVatLy { get; set; }
        public decimal diemHoaHoc { get; set; }
        public decimal diemSinhHoc { get; set; }
        public decimal diemLichSu { get; set; }
        public decimal diemDiaLi { get; set; }
        public decimal diemGDCD { get; set; }
    }
}
