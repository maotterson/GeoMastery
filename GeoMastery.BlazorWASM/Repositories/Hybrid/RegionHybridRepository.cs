using GeoMastery.Persistence.Data;
using GeoMastery.Persistence.Exceptions;
using GeoMastery.Domain.Models;
using Microsoft.EntityFrameworkCore;
using GeoMastery.Persistence.Repositories.v1;
using SqliteWasmHelper;
using GeoMastery.BlazorWASM.Repositories.ApiClient;

namespace GeoMastery.BlazorWASM.Repositories.Local;

public class RegionHybridRepository : IRegionRepository
{
    private readonly RegionLocalRepository _localRepository;
    private readonly RegionApiClient _apiClient;
    public RegionHybridRepository(RegionLocalRepository local, RegionApiClient apiClient)
    {
        _localRepository = local;
        _apiClient = apiClient;
    }

    public async Task<List<Region>> GetAllRegionsAsync()
    {
        var regions = await _localRepository.GetAllRegionsAsync();
        if (regions.Any())
        {
            return regions;
        }
        regions = await _apiClient.GetAllRegionsAsync();
        await _localRepository.AddRangeAsync(regions.ToArray());
        return regions;
    }

    public async Task<Region> GetRegionBySlugAsync(string slug)
    {
        return await _localRepository.GetRegionBySlugAsync(slug);
    }
}
