using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Calibration_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class suspenddispose : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SuspendDispose_table",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fld_dateReg = table.Column<DateTime>(type: "datetime2", nullable: true),
                    fld_ctrlNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_itemName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_calibType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_modelNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_serial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_brand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_reqFunction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_fixedAsset = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_requestBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_approvedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_reason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_drawingNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_suspendedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_disposalDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_submitdate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_receivedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_reqStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_inchargeQA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_followUpDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_nextFollowUp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_inchargeRequestor = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuspendDispose_table", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SuspendDispose_table");
        }
    }
}
