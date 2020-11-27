using Microsoft.EntityFrameworkCore;
using URC.Models;

public class StudentDB : DbContext
{
    public StudentDB(DbContextOptions<StudentDB> options)
        : base(options)
    {
    }

    public DbSet<Student> Students { get; set; }
    public DbSet<AppliedOpportunity> AppliedOpportunities { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>().ToTable("Student");
        modelBuilder.Entity<AppliedOpportunity>().ToTable("AppliedOpportunity");
    }
}