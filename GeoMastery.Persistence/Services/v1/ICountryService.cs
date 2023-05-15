using GeoMastery.Domain.Models;

namespace GeoMastery.Persistence.Services.v1;

public interface ICountryService
{
    Task<List<Country>> GetCountriesByRegionAsync(string regionSlug);
    Task<List<Country>> GetCountriesByContinentAsync(string continentSlug);
}
