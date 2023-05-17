namespace GeoMastery.Domain.Models;
public class City
{
    public Guid Id { get; set; }
    public Guid CountryId { get; set; }
    public Country Country { get; set; } = default!;
    public string Name { get; set; } = default!;
}
