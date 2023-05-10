using GeoMastery.Domain.Models;

namespace GeoMastery.CountriesAPI.Repositories.v1;

public interface ICountryRepository
{
    Task<List<Country>> GetCountriesByRegionAsync(Guid id);
    Task<List<Country>> GetCountriesByContinentAsync(Guid id);
}
