using System.Text.Json.Serialization;

namespace GeoMastery.Persistence.Data.Dto;

public class CountryRegionSeedDto
{
    [JsonPropertyName("country")]
    public string Country { get; set; } = default!;
    [JsonPropertyName("location")]
    public string Location { get; set; } = default!;
}
