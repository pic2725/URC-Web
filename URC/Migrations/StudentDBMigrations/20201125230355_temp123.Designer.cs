﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace URC.Migrations.StudentDBMigrations
{
    [DbContext(typeof(StudentDB))]
    [Migration("20201125230355_temp123")]
    partial class temp123
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("URC.Models.AppliedOpportunity", b =>
                {
                    b.Property<string>("StudentEmail")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("OpportunitiyID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StudentEmailAddress")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("StudentEmail");

                    b.HasIndex("StudentEmailAddress");

                    b.ToTable("AppliedOpportunity");
                });

            modelBuilder.Entity("URC.Models.Student", b =>
                {
                    b.Property<string>("EmailAddress")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ApplicationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DegreePlan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ExpectedGraduationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("GPA")
                        .HasColumnType("float");

                    b.Property<int>("HoursPerWeek")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Resume")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StudentCompletedCourses")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("StudentInterests")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("StudentSkills")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Uid")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("personalStatement")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("EmailAddress");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("URC.Models.AppliedOpportunity", b =>
                {
                    b.HasOne("URC.Models.Student", null)
                        .WithMany("AppliedOpportunity")
                        .HasForeignKey("StudentEmailAddress");
                });
#pragma warning restore 612, 618
        }
    }
}
