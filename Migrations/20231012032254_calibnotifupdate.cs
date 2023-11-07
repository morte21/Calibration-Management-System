using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Calibration_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class calibnotifupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CalibrationResultEQP",
                columns: table => new
                {
                    
                    calibrationdate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_actualCalibDueDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_codeNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_ctrlNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_eqpName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_eqpModelNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_serial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_brand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_term = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_reqFunction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_passFail = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    fld_dateReturned = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_withNC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_CalibFR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_calibDisSusForm = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_withCalibResult = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_incharge = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_changeSticker = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_dateRecv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalibrationResultEQP", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "CalibrationResultJIG",
                columns: table => new
                {
                    
                    calibrationdate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_actualCalibDueDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_ctrlNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_jigName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_drawingNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_term = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_reqFunction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_passfail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_imte = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_dateRecv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_calibDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_calibMonth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_calibYear = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_nextCalibDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_nextCalibMonth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_nextCalibYear = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_dateReturned = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_internalExternal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_withNC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_CalibFR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_calibDisSusForm = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_withCalibResult = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_pathDoc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_pathIMG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_incharge = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_changeSticker = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_codeNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalibrationResultJIG", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CalibrationResultEQP");

            migrationBuilder.DropTable(
                name: "CalibrationResultJIG");
        }
    }
}
