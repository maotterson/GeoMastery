using GeoMastery.Persistence.Exceptions;
using GeoMastery.Persistence.Repositories.v1;
using GeoMastery.Domain.Models;

namespace GeoMastery.Persistence.Services.v1;

public class RegionService : IRegionService
{
    private IRegionRepository _regionRepository;
    public RegionService(IRegionRepository regionRepository)
    {
        _regionRepository = regionRepository;
    }
    public async Task<List<Region>> GetAllRegionsAsync()
    {
        var regions = await _regionRepository.GetAllRegionsAsync();
        return regions;
    }

    public async Task<Region> GetRegionBySlugAsync(string slug)
    {
        var region = await _regionRepository.GetRegionBySlugAsync(slug);
        return region;
    }
}
