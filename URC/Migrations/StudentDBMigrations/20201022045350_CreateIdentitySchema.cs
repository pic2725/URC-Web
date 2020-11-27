using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace URC.Migrations.StudentDBMigrations
{
    public partial class CreateIdentitySchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Uid = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    EmailAddress = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Resume = table.Column<string>(nullable: true),
                    DegreePlan = table.Column<string>(nullable: false),
                    GPA = table.Column<double>(nullable: false),
                    HoursPerWeek = table.Column<int>(nullable: false),
                    personalStatement = table.Column<string>(maxLength: 100, nullable: true),
                    ExpectedGraduationDate = table.Column<DateTime>(nullable: false),
                    ApplicationDate = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    StudentSkills = table.Column<string>(maxLength: 50, nullable: true),
                    StudentCompletedCourses = table.Column<string>(maxLength: 50, nullable: true),
                    StudentInterests = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Uid);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Student");
        }
    }
}