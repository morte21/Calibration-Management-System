using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Calibration_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class ncr2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NCR_table",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fld_nonConReportNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_dateIssue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_ctrlNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_IssueTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_mainIncharge = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_modelNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_qty = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_withDisposalForm = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_contents = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_dateCompleted = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_calibReportNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_giveDisposeSuspendedForm = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_givenTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_rcvDisposeSuspendedForm = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_pathDoc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_pathIMG = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NCR_table", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NCR_table");
        }
    }
}
