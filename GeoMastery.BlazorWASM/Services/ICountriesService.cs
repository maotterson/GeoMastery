using GeoMastery.CountriesAPI.Contracts.Dto.v1;

namespace GeoMastery.BlazorWASM.Services;

public interface ICountriesService
{
    Task<RegionDto> GetRegionBySlugAsync(string slug);
}
