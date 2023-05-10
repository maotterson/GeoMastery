using GeoMastery.Domain.Models;

namespace GeoMastery.CountriesAPI.Services.v1;

public interface ICountryService
{
    Task<List<Country>> GetCountriesByRegionAsync(Guid id);
    Task<List<Country>> GetCountriesByContinentAsync(Guid id);
}
