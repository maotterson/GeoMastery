using GeoMastery.CountriesAPI.Contracts.Dto.v1;
using GeoMastery.Domain.Models;

namespace GeoMastery.BlazorWASM.Extensions;

public static class DtoExtensions
{
    public static Country ToCountry(CountryDto countryDto)
    {
        return new Country
        {
            Id = Guid.NewGuid(),
            Name = countryDto.Country,
            Code = countryDto.Code,
            Slug = countryDto.Slug,
            FlagBase64 = countryDto.FlagBase64,
            Population = countryDto.Population,
            CapitalId = countryDto.CapitalId,
            ContinentId = countryDto.ContinentId,
            RegionId = countryDto.RegionId,
        };
    }
}
