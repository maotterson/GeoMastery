using GeoMastery.CountriesAPI.Exceptions;
using GeoMastery.CountriesAPI.Repositories.v1;
using GeoMastery.Domain.Models;

namespace GeoMastery.CountriesAPI.Services.v1;

public class RegionService : IRegionService
{
    private IRegionRepository _regionRepository;
    public RegionService(IRegionRepository regionRepository)
    {
        _regionRepository = regionRepository;
    }
    public async Task<List<Country>> GetAllRegionsAsync()
    {
        var regions = await _regionRepository.GetAllRegionsAsync();
        return regions;
    }

}
