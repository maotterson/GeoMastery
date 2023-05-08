using System.Text.Json.Serialization;

namespace GeoMastery.BlazorWASM.Data.Dto;

public class CountryRegionSeedDto
{
    [JsonPropertyName("country")]
    public string Country { get; set; }
    [JsonPropertyName("location")]
    public string Location { get; set; }
}
