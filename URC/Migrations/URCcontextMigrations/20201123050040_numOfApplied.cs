using Microsoft.EntityFrameworkCore.Migrations;

namespace URC.Migrations.URCcontextMigrations
{
    public partial class numOfApplied : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SearchType",
                table: "Opportunity");

            migrationBuilder.AddColumn<int>(
                name: "numOfApplied",
                table: "Opportunity",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "numOfApplied",
                table: "Opportunity");

            migrationBuilder.AddColumn<string>(
                name: "SearchType",
                table: "Opportunity",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
