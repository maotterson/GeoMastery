using GeoMastery.CountriesAPI.Contracts.Dto.v1;
using GeoMastery.Domain.Models;

namespace GeoMastery.BlazorWASM.Extensions;

public static class DtoExtensions
{
    public static Country ToCountry(this CountryDto countryDto)
    {
        var country = new Country
        {
            Id = countryDto.Id,
            Name = countryDto.Country,
            Code = countryDto.Code,
            Slug = countryDto.Slug,
            FlagBase64 = countryDto.FlagBase64,
            Population = countryDto.Population,
            CapitalId = countryDto.CapitalId,
            
            // todo: add step to persist capital entities via Capital = countryDto.Capital
            ContinentId = countryDto.ContinentId,
            RegionId = countryDto.RegionId,
        };
        country.Capital = countryDto.CapitalId is not null ? new City
        {
            Id = (Guid)countryDto.CapitalId,
            CountryId = countryDto.Id,
            Name = countryDto.Country
        } : null;

        return country;
    }
    public static List<Country> ToCountries(this List<CountryDto> countryDtos)
    {
        return countryDtos.Select(c => c.ToCountry()).ToList();
    }
    public static Continent ToContinent(this ContinentDto continentDto)
    {
        return new Continent
        {
            Id = continentDto.Id,
            Name = continentDto.Name,
            Slug = continentDto.Slug
        };
    }
    public static List<Continent> ToContinents(this List<ContinentDto> continentDtos)
    {
        return continentDtos.Select(c => c.ToContinent()).ToList();
    }
    public static Region ToRegion(this RegionDto regionDto)
    {
        return new Region
        {
            Id = regionDto.Id,
            Name = regionDto.Name,
            Slug = regionDto.Slug
        };
    }
    public static List<Region> ToRegions(this List<RegionDto> regionDtos)
    {
        return regionDtos.Select(r => r.ToRegion()).ToList();
    }

    
}
