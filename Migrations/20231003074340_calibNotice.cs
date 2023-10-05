using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Calibration_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class calibNotice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CalibrationNotice_table",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fld_dateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    fld_pathEQP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_pathJIG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_stat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_dateApproved = table.Column<DateTime>(type: "datetime2", nullable: true),
                    fld_calibMonth = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fld_calibYear = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalibrationNotice_table", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CalibrationNotice_table");
        }
    }
}
