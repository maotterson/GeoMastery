using GeoMastery.Domain.Models;
using GeoMastery.Persistence.Repositories.v1;

namespace GeoMastery.BlazorWASM.Repositories.ApiClient;

public class CountryApiClient : ICountryRepository
{
    public Task<List<Country>> GetCountriesByContinentAsync(string continentSlug)
    {
        throw new NotImplementedException();
    }

    public Task<List<Country>> GetCountriesByRegionAsync(string regionSlug)
    {
        throw new NotImplementedException();
    }
}
