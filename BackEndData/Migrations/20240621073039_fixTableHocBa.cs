using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEndData.Migrations
{
    /// <inheritdoc />
    public partial class fixTableHocBa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HocLucCN",
                table: "HocBas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HocLucHK1",
                table: "HocBas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HocLucHK2",
                table: "HocBas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HocLucCN",
                table: "HocBas");

            migrationBuilder.DropColumn(
                name: "HocLucHK1",
                table: "HocBas");

            migrationBuilder.DropColumn(
                name: "HocLucHK2",
                table: "HocBas");
        }
    }
}
