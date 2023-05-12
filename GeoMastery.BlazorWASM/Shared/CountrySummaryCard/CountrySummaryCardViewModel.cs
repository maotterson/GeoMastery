using System.Text.Json.Serialization;

namespace GeoMastery.BlazorWASM.Shared.CountrySummaryCard;
public class CountrySummaryCardViewModel
{
    public string Country { get; set; } = default!;
    public string? Capital { get; set; }
    public string Slug { get; set; } = default!;
    public string Region { get; set; } = default!;
    public string Continent { get; set; } = default!;

    [JsonPropertyName("flag_base64")]
    public string? FlagBase64 { get; set; }
}
