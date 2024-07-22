﻿// <auto-generated />
using System;
using BackEndData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BackEndData.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240721115736_addnewTablePC1")]
    partial class addnewTablePC1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("BackEndData.Entities.CaHoc", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("TenCaHoc")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("CaHocs");
                });

            modelBuilder.Entity("BackEndData.Entities.ChiTietKyThi", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("Khoi")
                        .HasColumnType("int");

                    b.Property<Guid>("KyThiId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("MonThiId")
                        .HasColumnType("char(36)");

                    b.Property<string>("ThoiGianBatDau")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ThoiGianKetThuc")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("ThoiGianThi")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ChiTietKyThis");
                });

            modelBuilder.Entity("BackEndData.Entities.ChiTietLop", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("LopId")
                        .HasColumnType("char(36)");

                    b.Property<string>("NamHoc")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("ChiTietLops");
                });

            modelBuilder.Entity("BackEndData.Entities.DanToc", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("TenDanToc")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("DanTocs");
                });

            modelBuilder.Entity("BackEndData.Entities.DiemThi", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<decimal>("Diem")
                        .HasColumnType("decimal(65,30)");

                    b.Property<Guid>("KyThiId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("LopId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("MonThiId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("DiemThis");
                });

            modelBuilder.Entity("BackEndData.Entities.DiemTongKet", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<decimal>("Diem")
                        .HasColumnType("decimal(65,30)");

                    b.Property<Guid>("KyHocId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("LopId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("MonTongKetId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("DiemTongKets");
                });

            modelBuilder.Entity("BackEndData.Entities.HocBa", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<decimal>("DiaCN")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("DiaHK1")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("DiaHK2")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int>("DiemHKCN")
                        .HasColumnType("int");

                    b.Property<int>("DiemHKHK1")
                        .HasColumnType("int");

                    b.Property<int>("DiemHKHK2")
                        .HasColumnType("int");

                    b.Property<decimal>("DiemHoaCN")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("DiemHoaHK1")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("DiemHoaHK2")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("DiemLyCN")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("DiemLyHK1")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("DiemLyHK2")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("DiemTKCN")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("DiemTKHK1")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("DiemTKHK2")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("DiemToanCN")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("DiemToanHK1")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("DiemToanHK2")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("DiemVanCN")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("DiemVanHK1")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("DiemVanHK2")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("GDCDCN")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("GDCDHK1")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("GDCDHK2")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int>("HocLucCN")
                        .HasColumnType("int");

                    b.Property<int>("HocLucHK1")
                        .HasColumnType("int");

                    b.Property<int>("HocLucHK2")
                        .HasColumnType("int");

                    b.Property<decimal>("LichSuCN")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("LichSuHK1")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("LichSuHK2")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int?>("Lop")
                        .HasColumnType("int");

                    b.Property<decimal>("NgoaiNguCN")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("NgoaiNguHK1")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("NgoaiNguHK2")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("SinhCN")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("SinhHK1")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("SinhHK2")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("HocBas");
                });

            modelBuilder.Entity("BackEndData.Entities.KhoaHoc", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("TenKhoaHoc")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("KhoaHocs");
                });

            modelBuilder.Entity("BackEndData.Entities.Khoi", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("MaKhoi")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("TenKhoi")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Khois");
                });

            modelBuilder.Entity("BackEndData.Entities.KyHoc", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("NamHoc")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("NgayBatDau")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("NgayKetThuc")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("TenKyHoc")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("KyHocs");
                });

            modelBuilder.Entity("BackEndData.Entities.KyThi", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("KyHocId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("NgayBatDau")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("NgayKetThuc")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("TenKyThi")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("KyThis");
                });

            modelBuilder.Entity("BackEndData.Entities.LichThi", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("CaHocId")
                        .HasColumnType("char(36)");

                    b.Property<string>("KhoiHoc")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("KhoiThi")
                        .HasColumnType("int");

                    b.Property<Guid>("KyThiId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("MonThiId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("NgayThi")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("ThoiGianBatDau")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ThoiGianKetThuc")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("LichThis");
                });

            modelBuilder.Entity("BackEndData.Entities.Lop", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("Khoi")
                        .HasColumnType("int");

                    b.Property<string>("KhoiHoc")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("MaLop")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("TenLop")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Lops");
                });

            modelBuilder.Entity("BackEndData.Entities.MonHoc", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("Khoi")
                        .HasColumnType("int");

                    b.Property<string>("MaMonHoc")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("SoTietHoc")
                        .HasColumnType("int");

                    b.Property<string>("TenHocKy")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("TenMonHoc")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("MonHoc");
                });

            modelBuilder.Entity("BackEndData.Entities.MonThi", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("KhoiThi")
                        .HasColumnType("longtext");

                    b.Property<string>("MaMonThi")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("TenMonThi")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("MonThis");
                });

            modelBuilder.Entity("BackEndData.Entities.MonTongKet", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("MaMon")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("TenMon")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("MonTongKets");
                });

            modelBuilder.Entity("BackEndData.Entities.NamHoc", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("NameHoc")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("NamHocs");
                });

            modelBuilder.Entity("BackEndData.Entities.NguoiDung", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Avatar")
                        .HasColumnType("longtext");

                    b.Property<string>("CCCD")
                        .HasColumnType("longtext");

                    b.Property<Guid>("DanTocId")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("DanTocIdCha")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("DanTocIdMe")
                        .HasColumnType("char(36)");

                    b.Property<string>("DiaChi")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("DiaChiCha")
                        .HasColumnType("longtext");

                    b.Property<string>("DiaChiMe")
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<int>("GioiTinh")
                        .HasColumnType("int");

                    b.Property<string>("HoTen")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("HoTenCha")
                        .HasColumnType("longtext");

                    b.Property<string>("HoTenMe")
                        .HasColumnType("longtext");

                    b.Property<Guid?>("KhoaHocId")
                        .HasColumnType("char(36)");

                    b.Property<int?>("NamSinhCha")
                        .HasColumnType("int");

                    b.Property<int?>("NamSinhMe")
                        .HasColumnType("int");

                    b.Property<DateTime>("NgaySinh")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Propeties")
                        .HasColumnType("longtext");

                    b.Property<string>("SoDienThoai")
                        .HasColumnType("longtext");

                    b.Property<string>("SoDienThoaiCha")
                        .HasColumnType("longtext");

                    b.Property<string>("SoDienThoaiMe")
                        .HasColumnType("longtext");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<Guid>("TonGiaoId")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("TonGiaoIdCha")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("TonGiaoIdMe")
                        .HasColumnType("char(36)");

                    b.Property<int>("UserType")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("NguoiDungs");
                });

            modelBuilder.Entity("BackEndData.Entities.TaiKhoan", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("UserType")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("TaiKhoans");
                });

            modelBuilder.Entity("BackEndData.Entities.ThoiKhoaBieu", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("GiaoVienId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("KyHocId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("LopId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("MonHocId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("NgayHoc")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<Guid>("TietHocId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.ToTable("ThoiKhoaBieus");
                });

            modelBuilder.Entity("BackEndData.Entities.TietHoc", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("CaHocId")
                        .HasColumnType("char(36)");

                    b.Property<string>("TenTietHoc")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ThoiGianBatDau")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ThoiGianKetThuc")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("TietHocs");
                });

            modelBuilder.Entity("BackEndData.Entities.TonGiao", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("TenTonGiao")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("TonGiaos");
                });
#pragma warning restore 612, 618
        }
    }
}
