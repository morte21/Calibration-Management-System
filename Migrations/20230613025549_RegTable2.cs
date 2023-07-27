using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Calibration_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class RegTable2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Registration_Table",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fld_dateReg = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fld_reqFunction = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fld_incharge = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fld_approvedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fld_codeNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fld_reRegEquipmentCtrlNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fld_eqpName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fld_eqpModelNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fld_serial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fld_brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fld_submissionDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fld_receivedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fld_status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fld_emailOne = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fld_emailTwo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fld_emailThree = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fld_jigName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fld_drawingNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fld_reRegJigCtrlNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fld_jigCategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fld_remarks = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registration_Table", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Registration_Table");
        }
    }
}
