using System.Text.Json.Serialization;

namespace GeoMastery.CountriesAPI.Contracts.Dto.v1;

public class ContinentDto
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("slug")]
    public string Slug { get; set; }
    [JsonPropertyName("id")]
    public Guid Id { get; set; } = default!;
}