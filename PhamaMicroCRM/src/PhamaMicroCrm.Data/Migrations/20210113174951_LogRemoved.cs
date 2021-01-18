using Microsoft.EntityFrameworkCore.Migrations;

namespace PhamaMicroCrm.Data.Migrations
{
    public partial class LogRemoved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Log",
                table: "Log");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Log");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Log",
                type: "varchar(50)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Log");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Log",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Log",
                table: "Log",
                column: "Id");
        }
    }
}
