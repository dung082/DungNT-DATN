using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEndData.Migrations
{
    /// <inheritdoc />
    public partial class newTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DiemThis",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    KyThiId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Username = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LopId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    diemMonToan = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    diemMonVan = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    diemNgoaiNgu = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    diemVatLy = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    diemHoaHoc = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    diemSinhHoc = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    diemLichSu = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    diemDiaLi = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    diemGDCD = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiemThis", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiemThis");
        }
    }
}
