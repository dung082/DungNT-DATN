﻿using System;
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
        public Guid KyHocId { get; set; }
        public Guid LopId { get; set; }
        public Guid MonTongKetId { get; set; }
        public decimal Diem { get; set; }
    }
}
