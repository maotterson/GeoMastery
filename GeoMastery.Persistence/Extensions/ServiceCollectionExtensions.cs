using GeoMastery.Persistence.Data;
using Microsoft.Extensions.DependencyInjection;

namespace GeoMastery.Persistence.Extensions;
public static class ServiceCollectionExtensions
{
    public static void AddPersistence(this IServiceCollection services)
    {
        services.AddDbContext<CountryDbContext>();
        services.AddTransient<CountryDbSeeder>();
    }

}