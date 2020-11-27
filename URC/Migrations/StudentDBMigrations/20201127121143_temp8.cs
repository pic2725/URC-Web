using Microsoft.EntityFrameworkCore.Migrations;

namespace URC.Migrations.StudentDBMigrations
{
    public partial class temp8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProfessorEmail",
                table: "AppliedOpportunity",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfessorEmail",
                table: "AppliedOpportunity");
        }
    }
}
