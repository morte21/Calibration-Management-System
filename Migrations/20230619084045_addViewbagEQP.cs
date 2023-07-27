using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Calibration_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class addViewbagEQP : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category_table",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category_ = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category_table", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentCode_table",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EquipmentCode_ = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentCode_table", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Months_table",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Months_ = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Months_table", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Terms_table",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Terms_ = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Terms_table", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Category_table");

            migrationBuilder.DropTable(
                name: "EquipmentCode_table");

            migrationBuilder.DropTable(
                name: "Months_table");

            migrationBuilder.DropTable(
                name: "Terms_table");
        }
    }
}
