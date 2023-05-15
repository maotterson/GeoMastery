using GeoMastery.Persistence.Data;
using GeoMastery.Domain.Models;
using Microsoft.EntityFrameworkCore;
using GeoMastery.Persistence.Repositories.v1;
using SqliteWasmHelper;

namespace GeoMastery.BlazorWASM.Repositories.Local;

public class CountryHybridRepository : ICountryRepository
{
    private readonly ISqliteWasmDbContextFactory<CountryDbContext> _factory;
    public CountryHybridRepository(ISqliteWasmDbContextFactory<CountryDbContext> factory)
    {
        _factory = factory;
    }

    public async Task<List<Country>> GetCountriesByContinentAsync(string continentSlug)
    {
        using var ctx = await _factory.CreateDbContextAsync();
        var countries = await ctx.Countries
            .Include(c => c.Region)
            .Include(c => c.Continent)
            .Include(c => c.Capital)
            .Where(c => c.Continent.Slug == continentSlug)
            .OrderBy(c => c.Name)
            .ToListAsync();

        return countries;
    }

    public async Task<List<Country>> GetCountriesByRegionAsync(string regionSlug)
    {
        using var ctx = await _factory.CreateDbContextAsync();
        var countries = await ctx.Countries
           .Include(c => c.Region)
           .Include(c => c.Continent)
           .Include(c => c.Capital)
           .Where(c => c.Region.Slug == regionSlug)
           .OrderBy(c => c.Name)
           .ToListAsync();

        return countries;
    }
}
