using GeoMastery.CountriesAPI.Contracts.Dto.v1;
using System.Net.Http.Json;

namespace GeoMastery.BlazorWASM.Services;

public class CountriesService : ICountriesService
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;
    public CountriesService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;
    }
    private readonly Dictionary<string, RegionDto> _regionsCache = new Dictionary<string, RegionDto>();
    private readonly Dictionary<string, ContinentDto> _continentsCache = new Dictionary<string, ContinentDto>();
    private readonly Dictionary<string, CountryDto> _countriesCache = new Dictionary<string, CountryDto>();

    public async Task<RegionDto> GetRegionBySlugAsync(string slug)
    {
        if (_regionsCache.TryGetValue(slug, out var region))
        {
            return region;
        }

        // If the region is not in the cache, retrieve it from the API
        var baseUrl = _configuration["CountriesApi:BaseUrl"];
        var regionUri = $"{baseUrl}Region/by-slug/{slug}";
        region = await _httpClient.GetFromJsonAsync<RegionDto>(regionUri) ?? throw new NullReferenceException();

        // Add the region to the cache
        _regionsCache[slug] = region;

        return region;
    }
}
