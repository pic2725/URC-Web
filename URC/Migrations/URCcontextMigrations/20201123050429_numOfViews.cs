using Microsoft.EntityFrameworkCore.Migrations;

namespace URC.Migrations.URCcontextMigrations
{
    public partial class numOfViews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "numOfViews",
                table: "Opportunity",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "numOfViews",
                table: "Opportunity");
        }
    }
}
