using GeoMastery.BlazorWASM.Repositories.ApiClient;
using GeoMastery.BlazorWASM.Repositories.Local;
using GeoMastery.Persistence.Repositories.v1;

namespace GeoMastery.BlazorWASM.Extensions;

public static class DependencyInjection
{
    public static void UseLocalRepositories(this IServiceCollection services)
    {
        services.AddScoped<ICountryRepository, CountryLocalRepository>();
        services.AddScoped<IContinentRepository, ContinentLocalRepository>();
        services.AddScoped<IRegionRepository, RegionLocalRepository>();
    }

    public static void UseRemoteRepositories(this IServiceCollection services)
    {
        services.AddScoped<ICountryRepository, CountryApiClient>();
        services.AddScoped<IContinentRepository, ContinentApiClient>();
        services.AddScoped<IRegionRepository, RegionApiClient>();
    }
}
