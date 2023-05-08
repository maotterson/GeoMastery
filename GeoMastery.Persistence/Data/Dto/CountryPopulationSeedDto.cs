using System.Text.Json.Serialization;

namespace GeoMastery.BlazorWASM.Data.Dto;

public class CountryPopulationSeedDto
{
    [JsonPropertyName("country")]
    public string Country { get; set; }

    [JsonPropertyName("population")]
    public string Population { get; set; }
}
