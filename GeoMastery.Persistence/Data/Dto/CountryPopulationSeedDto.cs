using System.Text.Json.Serialization;

namespace GeoMastery.Persistence.Data.Dto;

public class CountryPopulationSeedDto
{
    [JsonPropertyName("country")]
    public string Country { get; set; } = default!;

    [JsonPropertyName("population")]
    public int Population { get; set; }
}
