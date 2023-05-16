using GeoMastery.Persistence.Data;
using SqliteWasmHelper;

namespace GeoMastery.BlazorWASM.Services;

public class SqliteDbService
{
    ISqliteWasmDbContextFactory<CountryDbContext> _factory;

    public SqliteDbService(ISqliteWasmDbContextFactory<CountryDbContext> factory)
    {
        _factory = factory;
    }

    public async Task GenerateDatabaseSchema()
    {
        using var ctx = await _factory.CreateDbContextAsync();
        await ctx.Database.EnsureCreatedAsync();
    }
}
