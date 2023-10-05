using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Calibration_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class genform : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GeneralForm_table",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fld_no = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_dateEst = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_appEquipment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_docNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_rev = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralForm_table", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GeneralForm_table");
        }
    }
}
