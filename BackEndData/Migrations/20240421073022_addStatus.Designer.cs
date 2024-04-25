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
    [Migration("20240421073022_addStatus")]
    partial class addStatus
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("BackEndData.Entities.ChiTietLop", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("LopId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("NamHocId")
                        .HasColumnType("char(36)");

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

            modelBuilder.Entity("BackEndData.Entities.Lop", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("IdKhoi")
                        .HasColumnType("char(36)");

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

                    b.Property<string>("MaMonHoc")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("TenMonHoc")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("MonHocs");
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

                    b.Property<Guid>("DanTocId")
                        .HasColumnType("char(36)");

                    b.Property<string>("DiaChi")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("GioiTinh")
                        .HasColumnType("int");

                    b.Property<string>("HoTen")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("NgaySinh")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Propeties")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("SoDienThoai")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Status")
                        .HasColumnType("int");

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
#pragma warning restore 612, 618
        }
    }
}
