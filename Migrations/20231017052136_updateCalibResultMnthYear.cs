using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Calibration_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class updateCalibResultMnthYear : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "fld_month",
                table: "CalibrationResultJIG",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "fld_year",
                table: "CalibrationResultJIG",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "fld_month",
                table: "CalibrationResultEQP",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "fld_year",
                table: "CalibrationResultEQP",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "fld_month",
                table: "CalibrationResultJIG");

            migrationBuilder.DropColumn(
                name: "fld_year",
                table: "CalibrationResultJIG");

            migrationBuilder.DropColumn(
                name: "fld_month",
                table: "CalibrationResultEQP");

            migrationBuilder.DropColumn(
                name: "fld_year",
                table: "CalibrationResultEQP");
        }
    }
}
