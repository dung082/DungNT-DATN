using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEndData.Migrations
{
    /// <inheritdoc />
    public partial class newMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HocBas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Username = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Lop = table.Column<int>(type: "int", nullable: true),
                    DiemTKHK1 = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    DiemTKHK2 = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    DiemTKCN = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    DiemHKHK1 = table.Column<int>(type: "int", nullable: false),
                    DiemHKHK2 = table.Column<int>(type: "int", nullable: false),
                    DiemHKCN = table.Column<int>(type: "int", nullable: false),
                    DiemToanHK1 = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    DiemToanHK2 = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    DiemToanCN = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    DiemVanHK1 = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    DiemVanHK2 = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    DiemVanCN = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    DiemLyHK1 = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    DiemLyHK2 = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    DiemLyCN = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    DiemHoaHK1 = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    DiemHoaHK2 = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    DiemHoaCN = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    SinhHK1 = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    SinhHK2 = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    SinhCN = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    LichSuHK1 = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    LichSuHK2 = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    LichSuCN = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    DiaHK1 = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    DiaHK2 = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    DiaCN = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    GDCDHK1 = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    GDCDHK2 = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    GDCDCN = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    NgoaiNguHK1 = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    NgoaiNguHK2 = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    NgoaiNguCN = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HocBas", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HocBas");
        }
    }
}
