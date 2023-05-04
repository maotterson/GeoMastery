using System.Text.Json.Serialization;

namespace GeoMastery.BlazorWASM.Shared.CountryFlagCard;
public class CountryFlagCardViewModel
{
    public string Country { get; set; }

    [JsonPropertyName("flag_base64")]
    public string FlagBase64 { get; set; }
}
