using System.Text.Json.Serialization;

namespace GeoMastery.BlazorWASM.Shared.CountrySummaryCard;
public class CountrySummaryCardViewModel
{
    public string Country { get; set; }
    public string Capital { get; set; }

    [JsonPropertyName("flag_base64")]
    public string FlagBase64 { get; set; }
}
