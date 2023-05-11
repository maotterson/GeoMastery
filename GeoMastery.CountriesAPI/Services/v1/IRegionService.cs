using GeoMastery.Domain.Models;

namespace GeoMastery.CountriesAPI.Services.v1;

public interface IRegionService
{
    Task<List<Region>> GetAllRegionsAsync();
}
