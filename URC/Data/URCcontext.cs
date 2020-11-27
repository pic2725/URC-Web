using Microsoft.EntityFrameworkCore;
using URC.Models;

public class URCcontext : DbContext
{
    public URCcontext(DbContextOptions<URCcontext> options)
        : base(options)
    {
    }

    public DbSet<Opportunity> Opportunities { get; set; }
    public DbSet<Student> Students { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Opportunity>().ToTable("Opportunity");
        modelBuilder.Entity<Student>().ToTable("Student");

    }
}