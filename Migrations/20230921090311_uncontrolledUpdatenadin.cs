using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Calibration_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class uncontrolledUpdatenadin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "fld_codeNo",
                table: "FailureReport_table");

            migrationBuilder.CreateTable(
                name: "Uncontrolled_table",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fld_nameEquip = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_modelType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_serial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_maker = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_reasonUncontrolled = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_qty = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_reqDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_reqBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_department = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fld_remarks = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uncontrolled_table", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Uncontrolled_table");

            migrationBuilder.AddColumn<string>(
                name: "fld_codeNo",
                table: "FailureReport_table",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
