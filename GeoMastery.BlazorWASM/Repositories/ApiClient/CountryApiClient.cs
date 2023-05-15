using GeoMastery.CountriesAPI.Contracts.Dto.v1;
using GeoMastery.Domain.Models;
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
        var requestUrl = baseUrl + "/countries/by-continent";

        var countries = await _httpClient.GetFromJsonAsync<List<CountryDto>>(requestUrl);

        // todo: create client side dto -> domain internal mapping mechanism
        return countries;
    }

    public async Task<List<Country>> GetCountriesByRegionAsync(string regionSlug)
    {
        var baseUrl = _configuration["CountriesApi:BaseUrl"];
        var requestUrl = baseUrl + "/countries/by-region";

        var countries = await _httpClient.GetFromJsonAsync<List<CountryDto>>(requestUrl);

        // todo: create client side dto -> domain internal mapping mechanism
        return countries;
    }
}
