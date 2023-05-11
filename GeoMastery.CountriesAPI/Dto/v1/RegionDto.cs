using System.Text.Json.Serialization;

namespace GeoMastery.CountriesAPI.Dto.v1;

public class RegionDto
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("slug")]
    public string Slug { get; set; }
}