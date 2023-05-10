using GeoMastery.CountriesAPI.Exceptions;
using GeoMastery.CountriesAPI.Repositories.v1;
using GeoMastery.Domain.Models;

namespace GeoMastery.CountriesAPI.Services.v1;

public class CountryService : ICountryService
{
    private ICountryRepository _countryRepository;
    public CountryService(ICountryRepository countryRepository)
    {
        _countryRepository = countryRepository;
    }
    public async Task<List<Country>> GetCountriesByContinentAsync(Guid id)
    {
        var countries = await _countryRepository.GetCountriesByContinentAsync(id);
        countries.MustExistBy(nameof(Continent));
        return countries;
    }

    public async Task<List<Country>> GetCountriesByRegionAsync(Guid id)
    {
        var countries = await _countryRepository.GetCountriesByRegionAsync(id);
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
