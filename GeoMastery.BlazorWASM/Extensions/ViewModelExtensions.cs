using GeoMastery.BlazorWASM.Shared.ContinentCard;
using GeoMastery.CountriesAPI.Contracts.Dto.v1;
using GeoMastery.Domain.Models;

namespace GeoMastery.CountriesAPI.Extensions.v1;

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
}