using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEndData.Migrations
{
    /// <inheritdoc />
    public partial class AddTonGiao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SoDienThoai",
                table: "NguoiDungs",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "CCCD",
                table: "NguoiDungs",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<Guid>(
                name: "DanTocIdCha",
                table: "NguoiDungs",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "DanTocIdMe",
                table: "NguoiDungs",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<string>(
                name: "DiaChiCha",
                table: "NguoiDungs",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "DiaChiMe",
                table: "NguoiDungs",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "HoTenCha",
                table: "NguoiDungs",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "HoTenMe",
                table: "NguoiDungs",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "NamSinhCha",
                table: "NguoiDungs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NamSinhMe",
                table: "NguoiDungs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SoDienThoaiCha",
                table: "NguoiDungs",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "SoDienThoaiMe",
                table: "NguoiDungs",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<Guid>(
                name: "TonGiaoId",
                table: "NguoiDungs",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "TonGiaoIdCha",
                table: "NguoiDungs",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "TonGiaoIdMe",
                table: "NguoiDungs",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.CreateTable(
                name: "TonGiaos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    TenTonGiao = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TonGiaos", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TonGiaos");

            migrationBuilder.DropColumn(
                name: "CCCD",
                table: "NguoiDungs");

            migrationBuilder.DropColumn(
                name: "DanTocIdCha",
                table: "NguoiDungs");

            migrationBuilder.DropColumn(
                name: "DanTocIdMe",
                table: "NguoiDungs");

            migrationBuilder.DropColumn(
                name: "DiaChiCha",
                table: "NguoiDungs");

            migrationBuilder.DropColumn(
                name: "DiaChiMe",
                table: "NguoiDungs");

            migrationBuilder.DropColumn(
                name: "HoTenCha",
                table: "NguoiDungs");

            migrationBuilder.DropColumn(
                name: "HoTenMe",
                table: "NguoiDungs");

            migrationBuilder.DropColumn(
                name: "NamSinhCha",
                table: "NguoiDungs");

            migrationBuilder.DropColumn(
                name: "NamSinhMe",
                table: "NguoiDungs");

            migrationBuilder.DropColumn(
                name: "SoDienThoaiCha",
                table: "NguoiDungs");

            migrationBuilder.DropColumn(
                name: "SoDienThoaiMe",
                table: "NguoiDungs");

            migrationBuilder.DropColumn(
                name: "TonGiaoId",
                table: "NguoiDungs");

            migrationBuilder.DropColumn(
                name: "TonGiaoIdCha",
                table: "NguoiDungs");

            migrationBuilder.DropColumn(
                name: "TonGiaoIdMe",
                table: "NguoiDungs");

            migrationBuilder.UpdateData(
                table: "NguoiDungs",
                keyColumn: "SoDienThoai",
                keyValue: null,
                column: "SoDienThoai",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "SoDienThoai",
                table: "NguoiDungs",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
