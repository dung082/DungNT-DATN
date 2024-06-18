using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEndData.Migrations
{
    /// <inheritdoc />
    public partial class optionize1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KhoiId",
                table: "ChiTietKyThis");

            migrationBuilder.AddColumn<int>(
                name: "Khoi",
                table: "ChiTietKyThis",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Khoi",
                table: "ChiTietKyThis");

            migrationBuilder.AddColumn<Guid>(
                name: "KhoiId",
                table: "ChiTietKyThis",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");
        }
    }
}
