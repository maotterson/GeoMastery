using System.Text.Json.Serialization;

namespace GeoMastery.Persistence.Data.Dto;

public class CountryContinentSeedDto
{
    [JsonPropertyName("country")]
    public string Country { get; set; } = default!;
    [JsonPropertyName("continent")]
    public string Continent { get; set; } = default!;
}
