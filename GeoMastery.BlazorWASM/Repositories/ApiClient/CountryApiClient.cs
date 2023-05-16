using GeoMastery.BlazorWASM.Extensions;
using GeoMastery.CountriesAPI.Contracts.Dto.v1;
using GeoMastery.Domain.Models;
using GeoMastery.Persistence.Exceptions;
using GeoMastery.Persistence.Repositories.v1;
using System.Net.Http.Json;

namespace GeoMastery.BlazorWASM.Repositories.ApiClient;

public class CountryApiClient : ICountryRepository
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;
    public CountryApiClient(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;
    }
    public async Task<List<Country>> GetCountriesByContinentAsync(string continentSlug)
    {
        var baseUrl = _configuration["CountriesApi:BaseUrl"];
        var requestUrl = baseUrl + $"country/by-continent/{continentSlug}";

        var countries = await _httpClient.GetFromJsonAsync<List<CountryDto>>(requestUrl);

        if (countries is null) throw new NotFoundException($"No countries found for continent ${continentSlug}.");

        return countries.ToCountries();
    }

    public async Task<List<Country>> GetCountriesByRegionAsync(string regionSlug)
    {
        var baseUrl = _configuration["CountriesApi:BaseUrl"];
        var requestUrl = baseUrl + $"country/by-region/{regionSlug}";

        var countries = await _httpClient.GetFromJsonAsync<List<CountryDto>>(requestUrl);

        if (countries is null) throw new NotFoundException($"No countries found for region ${regionSlug}.");

        return countries.ToCountries();
    }
}
