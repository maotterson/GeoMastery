using System.Text.Json.Serialization;

namespace GeoMastery.BlazorWASM.Data.Dto;

public class CountryFlagSeedDto
{
    [JsonPropertyName("country")]
    public string Country { get; set; }

    [JsonPropertyName("flag_base64")]
    public string FlagBase64 { get; set; }
}
