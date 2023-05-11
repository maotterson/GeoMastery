using GeoMastery.CountriesAPI.Dto.v1;
using GeoMastery.Domain.Models;

namespace GeoMastery.CountriesAPI.Extensions.v1;

public static class DtoExtensions
{
    public static CountryDto ToDto(this Country country)
    {
        return new CountryDto
        {
            Country = country.Name,
            Code = country.Code,
            Slug = country.Slug,
            Capital = country.Capital?.Name,
            Continent = country.Continent.Name,
            Region = country.Region.Name,
            Population = country.Population,
            FlagBase64 = country.FlagBase64
        };
    }

    public static List<CountryDto> ToDto(this List<Country> countries)
    {
        return countries.Select(c => c.ToDto()).ToList();
    }

    public static RegionDto ToDto(this Region region)
    {
        return new RegionDto
        {
            Name = region.Name,
            Slug = region.Slug
        };
    }

    public static List<RegionDto> ToDto(this List<Region> regions)
    {
        return regions.Select(r => r.ToDto()).ToList();
    }
}