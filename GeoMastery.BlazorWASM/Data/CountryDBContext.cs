using GeoMastery.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace GeoMastery.BlazorWASM.Data;

public class CountryDbContext : DbContext
{
    public DbSet<Country> Countries { get; set; }
    public DbSet<Country> Cities { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=countries.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Country>().HasKey(c => c.Name);
    }
}