using GeoMastery.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace GeoMastery.BlazorWASM.Data;

public class CountryDbContext : DbContext
{
    public DbSet<Country> Countries { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Continent> Continents { get; set; }
    public DbSet<Region> Regions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=countries.db"); 
        //optionsBuilder.UseSqlite("Data Source=:memory:");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Country>()
            .HasKey(c => c.Id);

        modelBuilder.Entity<City>()
            .HasKey(c => c.Id);

        modelBuilder.Entity<Continent>()
            .HasKey(c => c.Id);

        modelBuilder.Entity<Region>()
            .HasKey(r => r.Id);

        modelBuilder.Entity<Country>()
            .HasOne(c => c.Capital)
            .WithOne(c => c.Country)
            .HasForeignKey<City>(c => c.CountryId);

        modelBuilder.Entity<Country>()
            .HasOne(c => c.Continent)
            .WithMany(c => c.Countries)
            .HasForeignKey(c => c.ContinentId);

        modelBuilder.Entity<Country>()
            .HasOne(c => c.Region)
            .WithMany(r => r.Countries)
            .HasForeignKey(c => c.RegionId);
    }
}