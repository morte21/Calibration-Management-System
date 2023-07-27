using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Calibration_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class updateonly : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoUrl",
                table: "Equipment_table");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhotoUrl",
                table: "Equipment_table",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
