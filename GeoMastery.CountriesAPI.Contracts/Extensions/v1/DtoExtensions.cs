using GeoMastery.CountriesAPI.Contracts.Dto.v1;
using GeoMastery.Domain.Models;

namespace GeoMastery.CountriesAPI.Contracts.Extensions.v1;

public static class DtoExtensions
{
    public static CountryDto ToDto(this Country country)
    {
        return new CountryDto
        {
            Id = country.Id,
            Country = country.Name,
            Code = country.Code,
            Slug = country.Slug,
            Capital = country.Capital?.Name,
            CapitalId = country.CapitalId,
            Continent = country.Continent.Name,
            ContinentId = country.ContinentId,
            Region = country.Region.Name,
            RegionId = country.RegionId,
            Population = country.Population,
            FlagBase64 = country.FlagBase64,
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
            Id = region.Id,
            Name = region.Name,
            Slug = region.Slug,
        };
    }

    public static List<RegionDto> ToDto(this List<Region> regions)
    {
        return regions.Select(r => r.ToDto()).ToList();
    }

    public static ContinentDto ToDto(this Continent continent)
    {
        return new ContinentDto
        {
            Id = continent.Id,
            Name = continent.Name,
            Slug = continent.Slug
        };
    }

    public static List<ContinentDto> ToDto(this List<Continent> continents)
    {
        return continents.Select(r => r.ToDto()).ToList();
    }
}