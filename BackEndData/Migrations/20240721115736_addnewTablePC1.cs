using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEndData.Migrations
{
    /// <inheritdoc />
    public partial class addnewTablePC1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MonTongKet",
                table: "DiemTongKets",
                newName: "MonTongKetId");

            migrationBuilder.RenameColumn(
                name: "KyHoc",
                table: "DiemTongKets",
                newName: "LopId");

            migrationBuilder.AddColumn<Guid>(
                name: "KyHocId",
                table: "DiemTongKets",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.CreateTable(
                name: "LichThis",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    KyThiId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CaHocId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    KhoiThi = table.Column<int>(type: "int", nullable: false),
                    KhoiHoc = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NgayThi = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ThoiGianBatDau = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ThoiGianKetThuc = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MonThiId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LichThis", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LichThis");

            migrationBuilder.DropColumn(
                name: "KyHocId",
                table: "DiemTongKets");

            migrationBuilder.RenameColumn(
                name: "MonTongKetId",
                table: "DiemTongKets",
                newName: "MonTongKet");

            migrationBuilder.RenameColumn(
                name: "LopId",
                table: "DiemTongKets",
                newName: "KyHoc");
        }
    }
}
