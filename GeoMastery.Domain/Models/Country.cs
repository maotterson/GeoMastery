namespace GeoMastery.Domain.Models;
public class Country
{
    public Guid Id { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string Code { get; set; } = default!;
    public string Slug { get; set; } = default!;
    public string? FlagBase64 { get; set; }
    public int Population { get; set; } = default!;
    public Guid? CapitalId { get; set; }
    public City? Capital { get; set; }
    public Guid ContinentId { get; set; } = default!;
    public Continent Continent { get; set; } = default!;
    public Guid RegionId { get; set; } = default!;
    public Region Region { get; set; } = default!;
}
