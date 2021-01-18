using Microsoft.EntityFrameworkCore.Migrations;

namespace PhamaMicroCrm.Data.Migrations
{
    public partial class LogDroped : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Log");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Log",
                columns: table => new
                {
                    Text = table.Column<string>(type: "varchar(500)", nullable: false),
                    Type = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                });
        }
    }
}
