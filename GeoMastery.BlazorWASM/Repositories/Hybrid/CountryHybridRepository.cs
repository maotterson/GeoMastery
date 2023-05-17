using GeoMastery.Persistence.Data;
using GeoMastery.Domain.Models;
using Microsoft.EntityFrameworkCore;
using GeoMastery.Persistence.Repositories.v1;
using SqliteWasmHelper;
using GeoMastery.BlazorWASM.Repositories.ApiClient;

namespace GeoMastery.BlazorWASM.Repositories.Local;

public class CountryHybridRepository : ICountryRepository
{
    private readonly CountryLocalRepository _localRepository;
    private readonly CapitalLocalRepository _capitallocalRepository;
    private readonly CountryApiClient _apiClient;
    public CountryHybridRepository(CountryLocalRepository local, CountryApiClient apiClient, CapitalLocalRepository capitallocalRepository)
    {
        _localRepository = local;
        _apiClient = apiClient;
        _capitallocalRepository = capitallocalRepository;
    }

    public async Task<List<Country>> GetCountriesByContinentAsync(string continentSlug)
    {
        var countries = await _localRepository.GetCountriesByContinentAsync(continentSlug);
        if (countries.Any())
        {
            return countries;
        }
        countries = await _apiClient.GetCountriesByContinentAsync(continentSlug);
        await _localRepository.AddRangeAsync(countries.ToArray());
        return countries;
    }

    public async Task<List<Country>> GetCountriesByRegionAsync(string regionSlug)
    {
        var countries = await _localRepository.GetCountriesByRegionAsync(regionSlug);
        if (countries.Any())
        {
            return countries;
        }
        countries = await _apiClient.GetCountriesByRegionAsync(regionSlug);
        await _localRepository.AddRangeAsync(countries.ToArray());
        return countries;
    }
}
