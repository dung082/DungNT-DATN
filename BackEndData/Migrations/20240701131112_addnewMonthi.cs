using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEndData.Migrations
{
    /// <inheritdoc />
    public partial class addnewMonthi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "diemDiaLi",
                table: "DiemThis");

            migrationBuilder.DropColumn(
                name: "diemGDCD",
                table: "DiemThis");

            migrationBuilder.DropColumn(
                name: "diemHoaHoc",
                table: "DiemThis");

            migrationBuilder.DropColumn(
                name: "diemLichSu",
                table: "DiemThis");

            migrationBuilder.DropColumn(
                name: "diemMonToan",
                table: "DiemThis");

            migrationBuilder.DropColumn(
                name: "diemMonVan",
                table: "DiemThis");

            migrationBuilder.DropColumn(
                name: "diemNgoaiNgu",
                table: "DiemThis");

            migrationBuilder.DropColumn(
                name: "diemSinhHoc",
                table: "DiemThis");

            migrationBuilder.RenameColumn(
                name: "diemVatLy",
                table: "DiemThis",
                newName: "Diem");

            migrationBuilder.AddColumn<string>(
                name: "KhoiHoc",
                table: "Lops",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<Guid>(
                name: "MonThiId",
                table: "DiemThis",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.CreateTable(
                name: "MonThis",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    MaMonThi = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TenMonThi = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    KhoiThi = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonThis", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MonThis");

            migrationBuilder.DropColumn(
                name: "KhoiHoc",
                table: "Lops");

            migrationBuilder.DropColumn(
                name: "MonThiId",
                table: "DiemThis");

            migrationBuilder.RenameColumn(
                name: "Diem",
                table: "DiemThis",
                newName: "diemVatLy");

            migrationBuilder.AddColumn<decimal>(
                name: "diemDiaLi",
                table: "DiemThis",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "diemGDCD",
                table: "DiemThis",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "diemHoaHoc",
                table: "DiemThis",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "diemLichSu",
                table: "DiemThis",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "diemMonToan",
                table: "DiemThis",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "diemMonVan",
                table: "DiemThis",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "diemNgoaiNgu",
                table: "DiemThis",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "diemSinhHoc",
                table: "DiemThis",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
