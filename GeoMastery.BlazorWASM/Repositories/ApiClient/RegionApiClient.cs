using GeoMastery.CountriesAPI.Contracts.Dto.v1;
using GeoMastery.Domain.Models;
using GeoMastery.Persistence.Repositories.v1;
using System.Net.Http.Json;

namespace GeoMastery.BlazorWASM.Repositories.ApiClient;

public class RegionApiClient : IRegionRepository
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;
    public RegionApiClient(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;
    }
    public async Task<List<Region>> GetAllRegionsAsync()
    {
        var baseUrl = _configuration["CountriesApi:BaseUrl"];
        var requestUrl = baseUrl + "/regions";

        var regions = await _httpClient.GetFromJsonAsync<List<RegionDto>>(requestUrl);

        // todo: create client side dto -> domain internal mapping mechanism
        return regions;
    }

    public async Task<Region> GetRegionBySlugAsync(string slug)
    {
        var baseUrl = _configuration["CountriesApi:BaseUrl"];
        var requestUrl = baseUrl + $"/regions/{slug}";

        var region = await _httpClient.GetFromJsonAsync<RegionDto>(requestUrl);

        // todo: create client side dto -> domain internal mapping mechanism
        return region;
    }
}
