using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEndData.Migrations
{
    /// <inheritdoc />
    public partial class changeMonHoc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChuongTrinhKhungs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MonHocs",
                table: "MonHocs");

            migrationBuilder.RenameTable(
                name: "MonHocs",
                newName: "MonHoc");

            migrationBuilder.AddColumn<Guid>(
                name: "KhoiId",
                table: "MonHoc",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<int>(
                name: "SoTietHoc",
                table: "MonHoc",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "TenHocKy",
                table: "MonHoc",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MonHoc",
                table: "MonHoc",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MonHoc",
                table: "MonHoc");

            migrationBuilder.DropColumn(
                name: "KhoiId",
                table: "MonHoc");

            migrationBuilder.DropColumn(
                name: "SoTietHoc",
                table: "MonHoc");

            migrationBuilder.DropColumn(
                name: "TenHocKy",
                table: "MonHoc");

            migrationBuilder.RenameTable(
                name: "MonHoc",
                newName: "MonHocs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MonHocs",
                table: "MonHocs",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ChuongTrinhKhungs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    KhoiId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    MonHocId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    SoTietHoc = table.Column<int>(type: "int", nullable: false),
                    TenHocKy = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChuongTrinhKhungs", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
