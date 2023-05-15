using System.Text.Json.Serialization;

namespace GeoMastery.Persistence.Data.Dto;

public class CountryCapitalSeedDto
{
    [JsonPropertyName("capital")]
    public string Capital { get; set; }
    [JsonPropertyName("country")]
    public string Country { get; set; }
}
