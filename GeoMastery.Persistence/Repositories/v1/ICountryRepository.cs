using GeoMastery.Domain.Models;

namespace GeoMastery.Persistence.Repositories.v1;

public interface ICountryRepository
{
    Task<List<Country>> GetCountriesByRegionAsync(string regionSlug);
    Task<List<Country>> GetCountriesByContinentAsync(string continentSlug);
}
