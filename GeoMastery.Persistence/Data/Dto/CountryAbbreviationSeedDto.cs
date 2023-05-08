using System.Text.Json.Serialization;

namespace GeoMastery.BlazorWASM.Data.Dto;

public class CountryAbbreviationSeedDto
{
    [JsonPropertyName("abbreviation")]
    public string Abbreviation { get; set; }
    [JsonPropertyName("country")]
    public string Country { get; set; }
}
