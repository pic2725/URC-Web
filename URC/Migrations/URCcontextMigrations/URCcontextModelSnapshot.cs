﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace URC.Migrations.URCcontextMigrations
{
    [DbContext(typeof(URCcontext))]
    partial class URCcontextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("URC.Models.Opportunity", b =>
                {
                    b.Property<int>("OpportunityID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AssociatedImag")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("BeginningDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Department")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Filled")
                        .HasColumnType("bit");

                    b.Property<string>("Pay")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfessorEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfessorName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProjectName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RequiredSkills")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SearchTags")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StudentMentor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("numOfApplied")
                        .HasColumnType("int");

                    b.Property<int>("numOfViews")
                        .HasColumnType("int");

                    b.HasKey("OpportunityID");

                    b.ToTable("Opportunity");
                });
#pragma warning restore 612, 618
        }
    }
}
