using GeoMastery.Persistence.Exceptions;
using GeoMastery.Persistence.Repositories.v1;
using GeoMastery.Domain.Models;

namespace GeoMastery.Persistence.Services.v1;

public class CountryService : ICountryService
{
    private ICountryRepository _countryRepository;
    public CountryService(ICountryRepository countryRepository)
    {
        _countryRepository = countryRepository;
    }
    public async Task<List<Country>> GetCountriesByContinentAsync(string continentSlug)
    {
        var countries = await _countryRepository.GetCountriesByContinentAsync(continentSlug);
        countries.MustExistBy(nameof(Continent));
        return countries;
    }

    public async Task<List<Country>> GetCountriesByRegionAsync(string regionSlug)
    {
        var countries = await _countryRepository.GetCountriesByRegionAsync(regionSlug);
        countries.MustExistBy(nameof(Region));
        return countries;
    }

    
}
public static class CountryServiceExtensions
{
    public static void MustExistBy(this List<Country>? countries, string type)
    {
        if (countries == null || countries.Count == 0)
        {
            throw new NotFoundException($"No countries found for the given {type}.");
        }
        return;
    }
}
