using SIMS.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace SIMS.Data;

public class SIMSContext:DbContext
{
    public SIMSContext(DbContextOptions<SIMSContext> options):base(options)
    {
        
    }

    public DbSet<Courses> Courses{get; set;}
    public DbSet<Students> Students{get; set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Students>()
        .HasOne(ea => ea.Courses)
        .WithMany(e => e.Students)
        .HasForeignKey(ea => ea.CourseId);
    }

}