using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEndData.Migrations
{
    /// <inheritdoc />
    public partial class optionize : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KhoiId",
                table: "MonHoc");

            migrationBuilder.DropColumn(
                name: "IdKhoi",
                table: "Lops");

            migrationBuilder.DropColumn(
                name: "NamHocId",
                table: "KyHocs");

            migrationBuilder.DropColumn(
                name: "NamHocId",
                table: "ChiTietLops");

            migrationBuilder.AddColumn<int>(
                name: "Khoi",
                table: "MonHoc",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Khoi",
                table: "Lops",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "NamHoc",
                table: "KyHocs",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "NamHoc",
                table: "ChiTietLops",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Khoi",
                table: "MonHoc");

            migrationBuilder.DropColumn(
                name: "Khoi",
                table: "Lops");

            migrationBuilder.DropColumn(
                name: "NamHoc",
                table: "KyHocs");

            migrationBuilder.DropColumn(
                name: "NamHoc",
                table: "ChiTietLops");

            migrationBuilder.AddColumn<Guid>(
                name: "KhoiId",
                table: "MonHoc",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "IdKhoi",
                table: "Lops",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "NamHocId",
                table: "KyHocs",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "NamHocId",
                table: "ChiTietLops",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");
        }
    }
}
