using Microsoft.EntityFrameworkCore.Migrations;

namespace URC.Migrations.StudentDBMigrations
{
    public partial class temp1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AppliedOpportunity",
                table: "AppliedOpportunity");

            migrationBuilder.AlterColumn<string>(
                name: "StudentEmail",
                table: "AppliedOpportunity",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "AppliedOpportunityID",
                table: "AppliedOpportunity",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppliedOpportunity",
                table: "AppliedOpportunity",
                column: "AppliedOpportunityID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AppliedOpportunity",
                table: "AppliedOpportunity");

            migrationBuilder.DropColumn(
                name: "AppliedOpportunityID",
                table: "AppliedOpportunity");

            migrationBuilder.AlterColumn<string>(
                name: "StudentEmail",
                table: "AppliedOpportunity",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppliedOpportunity",
                table: "AppliedOpportunity",
                column: "StudentEmail");
        }
    }
}
