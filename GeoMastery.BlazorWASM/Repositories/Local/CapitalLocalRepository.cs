using GeoMastery.Domain.Models;
using GeoMastery.Persistence.Data;
using SqliteWasmHelper;

namespace GeoMastery.BlazorWASM.Repositories.Local;

public class CapitalLocalRepository
{
    private readonly ISqliteWasmDbContextFactory<CountryDbContext> _factory;
    public CapitalLocalRepository(ISqliteWasmDbContextFactory<CountryDbContext> factory)
    {
        _factory = factory;
    }

    public async Task AddFromCountriesAsync(params Country[] countries)
    {
        using var ctx = await _factory.CreateDbContextAsync();
        foreach(var c in countries)
        {
            if (c.Capital is not null)
            {
                Console.WriteLine(c.Name);
                Console.WriteLine(c.Capital.Name);
                await ctx.Cities.AddAsync(c.Capital);
            }
        }
        await ctx.SaveChangesAsync();
    }

    public async Task AddAsync(City capital)
    {
        using var ctx = await _factory.CreateDbContextAsync();
        await ctx.Cities.AddAsync(capital);
        await ctx.SaveChangesAsync();
    }
}
