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
        public DbSet<KhoaHoc> KhoaHocs { get; set; }
        public DbSet<TonGiao> TonGiaos { get; set; }
        public DbSet<KyHoc> KyHocs { get; set; }
        public DbSet<KyThi> KyThis { get; set; }
        public DbSet<ChiTietKyThi> ChiTietKyThis { get; set; }
        public DbSet<MonHoc> ChuongTrinhKhungs { get; set; }
        public DbSet<CaHoc> CaHocs { get; set; }
        public DbSet<TietHoc> TietHocs { get; set; }
        public DbSet<ThoiKhoaBieu> ThoiKhoaBieus { get; set; }
        public DbSet<HocBa> HocBas { get; set; }
        public DbSet<DiemThi> DiemThis { get; set; }
        public DbSet<MonThi> MonThis { get; set; }
        public DbSet<MonTongKet> MonTongKets { get; set; }
        public DbSet<DiemTongKet> DiemTongKets { get; set; }
        public DbSet<LichThi> LichThis { get; set; }
        public DbSet<DiemDanh> DiemDanhs{ get; set; }
        public DbSet<ThongBao> ThongBaos { get; set;}
    }
}
