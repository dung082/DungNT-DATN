using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEndData.Migrations
{
    /// <inheritdoc />
    public partial class FixTableLapTop7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ThoiKhoaBieus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    TietHocId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    NgayHoc = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    KyHocId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    LopId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    MonHocId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    GiaoVienId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThoiKhoaBieus", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ThoiKhoaBieus");
        }
    }
}
