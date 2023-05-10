using GeoMastery.Domain.Models;

namespace GeoMastery.CountriesAPI.Services.v1;

public interface ICountryService
{
    Task<List<Country>> GetCountriesByRegionAsync(string regionSlug);
    Task<List<Country>> GetCountriesByContinentAsync(string continentSlug);
}
