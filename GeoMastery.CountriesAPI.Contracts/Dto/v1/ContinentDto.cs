using System.Text.Json.Serialization;

namespace GeoMastery.CountriesAPI.Contracts.Dto.v1;

public class ContinentDto
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = default!;

    [JsonPropertyName("slug")]
    public string Slug { get; set; } = default!;
    [JsonPropertyName("id")]
    public Guid Id { get; set; } = default!;
}