using System.Text.Json.Serialization;

namespace GeoMastery.Persistence.Data.Dto;

public class CountryAbbreviationSeedDto
{
    [JsonPropertyName("abbreviation")]
    public string Abbreviation { get; set; } = default!;
    [JsonPropertyName("country")]
    public string Country { get; set; } = default!;
}
