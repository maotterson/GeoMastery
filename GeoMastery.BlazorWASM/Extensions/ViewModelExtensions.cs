using GeoMastery.BlazorWASM.Shared.ContinentCard;
using GeoMastery.BlazorWASM.Shared.CountrySummaryCard;
using GeoMastery.BlazorWASM.Shared.RegionCard;
using GeoMastery.CountriesAPI.Contracts.Dto.v1;

namespace GeoMastery.BlazorWASM.Extensions;

public static class ViewModelExtensions
{
    public static ContinentCardViewModel ToViewModel(this ContinentDto continent)
    {
        return new ContinentCardViewModel
        {
            Name = continent.Name,
            Slug = continent.Slug
        };
    }

    public static List<ContinentCardViewModel> ToDto(this List<ContinentDto> continents)
    {
        return continents.Select(c => c.ToViewModel()).ToList();
    }

    public static RegionCardViewModel ToViewModel(this RegionDto region)
    {
        return new RegionCardViewModel
        {
            Name = region.Name,
            Slug = region.Slug
        };
    }
    public static List<RegionCardViewModel> ToDto(this List<RegionDto> regions)
    {
        return regions.Select(c => c.ToViewModel()).ToList();
    }

    public static CountrySummaryCardViewModel ToSummaryCardViewModel(this CountryDto country)
    {
        return new CountrySummaryCardViewModel
        {
            Country = country.Country,
            Slug = country.Slug,
            Continent = country.Continent,
            FlagBase64 = country.FlagBase64,
            Capital = country.Capital,
            Region = country.Region
        };
    }
    public static List<CountrySummaryCardViewModel> ToSummaryCardViewModel(this List<CountryDto> countries)
    {
        return countries.Select(c => c.ToSummaryCardViewModel()).ToList();
    }
}