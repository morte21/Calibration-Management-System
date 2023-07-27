using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Calibration_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class addJig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Jig_table",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fld_codeNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_ctrlNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_division = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_jigName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_drawingNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_serialNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_term = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_reqFunction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_passfail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_registrationDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_imte = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_calibDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_calibMonth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_calibYear = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_nextCalibDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_nextCalibMonth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_nextCalibYear = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_internalExternal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_pathDoc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_pathIMG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_stat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jig_table", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Jig_table");
        }
    }
}
