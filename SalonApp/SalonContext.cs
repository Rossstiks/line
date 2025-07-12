using Microsoft.EntityFrameworkCore;
using SalonApp.Models;

namespace SalonApp;

public class SalonContext : DbContext
{
    public DbSet<MonthlyRecord> MonthlyRecords { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlite("Data Source=salon.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MonthlyRecord>()
            .HasIndex(m => new { m.Year, m.Month })
            .IsUnique();
    }
}
