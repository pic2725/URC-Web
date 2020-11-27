using Microsoft.EntityFrameworkCore.Migrations;

namespace URC.Migrations.StudentDBMigrations
{
    public partial class temp123 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Student",
                table: "Student");

            migrationBuilder.AlterColumn<string>(
                name: "EmailAddress",
                table: "Student",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Uid",
                table: "Student",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Student",
                table: "Student",
                column: "EmailAddress");

            migrationBuilder.CreateTable(
                name: "AppliedOpportunity",
                columns: table => new
                {
                    StudentEmail = table.Column<string>(nullable: false),
                    OpportunitiyID = table.Column<string>(nullable: true),
                    StudentEmailAddress = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppliedOpportunity", x => x.StudentEmail);
                    table.ForeignKey(
                        name: "FK_AppliedOpportunity_Student_StudentEmailAddress",
                        column: x => x.StudentEmailAddress,
                        principalTable: "Student",
                        principalColumn: "EmailAddress",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppliedOpportunity_StudentEmailAddress",
                table: "AppliedOpportunity",
                column: "StudentEmailAddress");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppliedOpportunity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Student",
                table: "Student");

            migrationBuilder.AlterColumn<string>(
                name: "Uid",
                table: "Student",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "EmailAddress",
                table: "Student",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Student",
                table: "Student",
                column: "Uid");
        }
    }
}
