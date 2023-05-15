using GeoMastery.Domain.Models;
using GeoMastery.Persistence.Repositories.v1;

namespace GeoMastery.BlazorWASM.Repositories.ApiClient;

public class RegionApiClient : IRegionRepository
{
    public Task<List<Region>> GetAllRegionsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Region> GetRegionBySlugAsync(string slug)
    {
        throw new NotImplementedException();
    }
}
