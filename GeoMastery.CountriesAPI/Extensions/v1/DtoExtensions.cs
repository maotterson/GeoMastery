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
}