using System.Text.Json.Serialization;

namespace GeoMastery.BlazorWASM.Data.Dto;

public class CountryCitiesSeedDto
{
    [JsonPropertyName("country")]
    public string Country { get; set; }
    [JsonPropertyName("cities")]
    public List<string> Cities { get; set; }
}