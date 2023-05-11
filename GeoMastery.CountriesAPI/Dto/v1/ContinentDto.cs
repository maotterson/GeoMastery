using System.Text.Json.Serialization;

namespace GeoMastery.CountriesAPI.Dto.v1;

public class ContinentDto
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("slug")]
    public string Slug { get; set; }
}