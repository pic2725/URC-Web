using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace URC.Migrations.StudentDBMigrations
{
    public partial class temp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Accepted",
                table: "AppliedOpportunity",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "AppliedDate",
                table: "AppliedOpportunity",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Denied",
                table: "AppliedOpportunity",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Pending",
                table: "AppliedOpportunity",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Processing",
                table: "AppliedOpportunity",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Accepted",
                table: "AppliedOpportunity");

            migrationBuilder.DropColumn(
                name: "AppliedDate",
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
        }
    }
}
