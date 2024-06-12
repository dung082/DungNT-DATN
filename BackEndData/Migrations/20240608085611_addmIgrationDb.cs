using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEndData.Migrations
{
    /// <inheritdoc />
    public partial class addmIgrationDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ThoiGianKetThuc",
                table: "TietHocs",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(TimeOnly),
                oldType: "time(6)")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "ThoiGianBatDau",
                table: "TietHocs",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(TimeOnly),
                oldType: "time(6)")
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeOnly>(
                name: "ThoiGianKetThuc",
                table: "TietHocs",
                type: "time(6)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<TimeOnly>(
                name: "ThoiGianBatDau",
                table: "TietHocs",
                type: "time(6)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
