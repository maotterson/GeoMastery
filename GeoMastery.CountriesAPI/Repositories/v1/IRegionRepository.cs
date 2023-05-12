using GeoMastery.Domain.Models;

namespace GeoMastery.CountriesAPI.Repositories.v1;

public interface IRegionRepository
{
    Task<List<Region>> GetAllRegionsAsync();
    Task<Region> GetRegionBySlugAsync(string slug);
}
