using Microsoft.EntityFrameworkCore.Migrations;

namespace URC.Migrations.StudentDBMigrations
{
    public partial class temp7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Accepted",
                table: "AppliedOpportunity");

            migrationBuilder.DropColumn(
                name: "Denied",
                table: "AppliedOpportunity");

            migrationBuilder.DropColumn(
                name: "Pending",
                table: "AppliedOpportunity");

            migrationBuilder.DropColumn(
                name: "Processing",
                table: "AppliedOpportunity");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "AppliedOpportunity",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "AppliedOpportunity");

            migrationBuilder.AddColumn<bool>(
                name: "Accepted",
                table: "AppliedOpportunity",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Denied",
                table: "AppliedOpportunity",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Pending",
                table: "AppliedOpportunity",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Processing",
                table: "AppliedOpportunity",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
