using System.Text.Json.Serialization;

namespace GeoMastery.CountriesAPI.Contracts.Dto.v1;

public class CountryDto
{
    [JsonPropertyName("name")]
    public string Country { get; set; }

    [JsonPropertyName("code")]
    public string Code { get; set; }

    [JsonPropertyName("continent")]
    public string Continent { get; set; }

    [JsonPropertyName("capital")]
    public string? Capital { get; set; }
    [JsonPropertyName("slug")]
    public string Slug { get; set; }

    [JsonPropertyName("region")]
    public string Region { get; set; }

    [JsonPropertyName("population")]
    public int Population { get; set; }

    [JsonPropertyName("flag_base_64")]
    public string? FlagBase64 { get; set; }
}