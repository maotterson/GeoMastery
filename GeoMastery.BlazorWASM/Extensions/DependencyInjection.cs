using GeoMastery.BlazorWASM.Repositories.ApiClient;
using GeoMastery.BlazorWASM.Repositories.Local;
using GeoMastery.BlazorWASM.Services;
using GeoMastery.Persistence.Data;
using GeoMastery.Persistence.Repositories.v1;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SqliteWasmHelper;

namespace GeoMastery.BlazorWASM.Extensions;

public static class DependencyInjection
{
    public static bool RegisterRepositories(this IServiceCollection services, bool hybrid)
    {
        if (hybrid)
        {
            services.UseHybridRepositories();
        }
        else
        {
            services.UseHybridRepositories();
        }
        return hybrid;
    }
    public static void UseLocalRepositories(this IServiceCollection services)
    {
        services.AddScoped<ICountryRepository, CountryLocalRepository>();
        services.AddScoped<IContinentRepository, ContinentLocalRepository>();
        services.AddScoped<IRegionRepository, RegionLocalRepository>();
    }

    public static void UseHybridRepositories(this IServiceCollection services)
    {
        services.AddScoped<CountryLocalRepository>();
        services.AddScoped<ContinentLocalRepository>();
        services.AddScoped<RegionLocalRepository>();
        services.AddScoped<CountryApiClient>();
        services.AddScoped<ContinentApiClient>();
        services.AddScoped<RegionApiClient>();
        services.AddScoped<ICountryRepository, CountryHybridRepository>();
        services.AddScoped<IContinentRepository, ContinentHybridRepository>();
        services.AddScoped<IRegionRepository, RegionHybridRepository>();
    }
    
    public static async Task SeedDataLocally(this WebAssemblyHost host)
    {
        var factory = host.Services.GetRequiredService<ISqliteWasmDbContextFactory<CountryDbContext>>();
        var httpClient = host.Services.GetRequiredService<HttpClient>();
        using var ctx = await factory.CreateDbContextAsync();
        var seeder = new HttpCountryDbSeeder(ctx, httpClient);
        await seeder.SeedCountries("sample-data");
    }

}
