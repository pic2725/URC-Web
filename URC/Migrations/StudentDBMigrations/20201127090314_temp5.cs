using Microsoft.EntityFrameworkCore.Migrations;

namespace URC.Migrations.StudentDBMigrations
{
    public partial class temp5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OpportunitiyName",
                table: "AppliedOpportunity",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OpportunityDepartment",
                table: "AppliedOpportunity",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OpportunityProfessor",
                table: "AppliedOpportunity",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OpportunitiyName",
                table: "AppliedOpportunity");

            migrationBuilder.DropColumn(
                name: "OpportunityDepartment",
                table: "AppliedOpportunity");

            migrationBuilder.DropColumn(
                name: "OpportunityProfessor",
                table: "AppliedOpportunity");
        }
    }
}
