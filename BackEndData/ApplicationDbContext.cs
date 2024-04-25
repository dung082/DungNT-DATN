using BackEndData.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndData
{
    public class ApplicationDbContext : DbContext
    {
        public  ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        
        public DbSet<Khoi> Khois { get; set; }
        public DbSet<Lop> Lops { get; set; }
        public DbSet<TaiKhoan> TaiKhoans { get; set; }
        public DbSet<MonHoc> MonHocs { get; set; }
        public DbSet<NamHoc> NamHocs{ get; set; }
        public DbSet<NguoiDung> NguoiDungs { get; set; }
        public DbSet<ChiTietLop> ChiTietLops { get; set; }
        public DbSet<DanToc> DanTocs { get; set; }
    }
}
