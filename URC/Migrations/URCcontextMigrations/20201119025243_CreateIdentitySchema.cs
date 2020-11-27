using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace URC.Migrations.URCcontextMigrations
{
    public partial class CreateIdentitySchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Opportunity",
                columns: table => new
                {
                    OpportunityID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectName = table.Column<string>(nullable: true),
                    ProfessorName = table.Column<string>(nullable: true),
                    ProfessorEmail = table.Column<string>(nullable: true),
                    Department = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    AssociatedImag = table.Column<string>(nullable: true),
                    StudentMentor = table.Column<string>(nullable: true),
                    BeginningDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    Pay = table.Column<string>(nullable: true),
                    Filled = table.Column<bool>(nullable: false),
                    RequiredSkills = table.Column<string>(nullable: true),
                    SearchTags = table.Column<string>(nullable: true),
                    SearchType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Opportunity", x => x.OpportunityID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Opportunity");
        }
    }
}