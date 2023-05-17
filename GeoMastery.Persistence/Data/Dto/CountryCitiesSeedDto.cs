using System.Text.Json.Serialization;

namespace GeoMastery.Persistence.Data.Dto;

public class CountryCitiesSeedDto
{
    [JsonPropertyName("country")]
    public string Country { get; set; } = default!;
    [JsonPropertyName("cities")]
    public List<string> Cities { get; set; } = default!;
}