using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEndData.Migrations
{
    /// <inheritdoc />
    public partial class addMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KhoaHoc",
                table: "NguoiDungs");

            migrationBuilder.AddColumn<Guid>(
                name: "KhoaHocId",
                table: "NguoiDungs",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.CreateTable(
                name: "CaHocs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    TenCaHoc = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaHocs", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ChiTietKyThis",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    KyThiId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    KhoiId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    MonThiId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ThoiGianThi = table.Column<int>(type: "int", nullable: false),
                    ThoiGianBatDau = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ThoiGianKetThuc = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietKyThis", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ChuongTrinhKhungs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    MonHocId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    KhoiId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    TenHocKy = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SoTietHoc = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChuongTrinhKhungs", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "KyHocs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    NamHocId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    TenKyHoc = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NgayBatDau = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    NgayKetThuc = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KyHocs", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "KyThis",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    TenKyThi = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    KyHocId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    NgayBatDau = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    NgayKetThuc = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KyThis", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ThoiKhoaBieus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TietHocId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    NgayHoc = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    NamHoc = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    LopId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    MonHocId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    GiaoVienId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThoiKhoaBieus", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TietHocs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    TenTietHoc = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CaHocId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ThoiGianBatDau = table.Column<TimeOnly>(type: "time(6)", nullable: false),
                    ThoiGianKetThuc = table.Column<TimeOnly>(type: "time(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TietHocs", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CaHocs");

            migrationBuilder.DropTable(
                name: "ChiTietKyThis");

            migrationBuilder.DropTable(
                name: "ChuongTrinhKhungs");

            migrationBuilder.DropTable(
                name: "KyHocs");

            migrationBuilder.DropTable(
                name: "KyThis");

            migrationBuilder.DropTable(
                name: "ThoiKhoaBieus");

            migrationBuilder.DropTable(
                name: "TietHocs");

            migrationBuilder.DropColumn(
                name: "KhoaHocId",
                table: "NguoiDungs");

            migrationBuilder.AddColumn<string>(
                name: "KhoaHoc",
                table: "NguoiDungs",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
