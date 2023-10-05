using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Calibration_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class failurereport2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FailureReport_table",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fld_codeNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_reportNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_dateIssue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_deptsec = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_incharge = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_mainincharge = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_ctrlNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_EquipName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_qty = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_contents = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_pathDoc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_pathIMG = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FailureReport_table", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FailureReport_table");
        }
    }
}
