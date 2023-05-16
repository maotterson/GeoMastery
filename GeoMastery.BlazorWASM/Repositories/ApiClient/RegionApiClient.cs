using GeoMastery.BlazorWASM.Extensions;
using GeoMastery.CountriesAPI.Contracts.Dto.v1;
using GeoMastery.Domain.Models;
using GeoMastery.Persistence.Exceptions;
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
        var requestUrl = baseUrl + "region";

        var regions = await _httpClient.GetFromJsonAsync<List<RegionDto>>(requestUrl);

        if (regions is null) throw new NotFoundException($"No regions found.");

        return regions.ToRegions();
    }

    public async Task<Region> GetRegionBySlugAsync(string slug)
    {
        var baseUrl = _configuration["CountriesApi:BaseUrl"];
        var requestUrl = baseUrl + $"region/{slug}";

        var region = await _httpClient.GetFromJsonAsync<RegionDto>(requestUrl);

        if (region is null) throw new NotFoundException($"No region found with slug ${slug}.");

        return region.ToRegion();
    }
}
