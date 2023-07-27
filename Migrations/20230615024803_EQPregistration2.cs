using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Calibration_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class EQPregistration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Equipment_table",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fld_codeNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_ctrlNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_division = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_code2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_eqpName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_eqpModelNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_serial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_brand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_term = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_reqFunction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_passFail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_registrationDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_imte = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_calibDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_calibMonth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_calibYear = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_nextCalibDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_nextCalibMonth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_nextCalibYear = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_internalExternal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_supplierExternal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_appStandardEqp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_pathIMG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_pathDoc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_stat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_calibResult = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_imgResult = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_updatedToSystem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_updatedToMasterlist = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_withNCR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_withFailureReport = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_withDisSus = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment_table", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Equipment_table");
        }
    }
}
