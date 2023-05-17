namespace GeoMastery.Domain.Models;
public class Region
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string Slug { get; set; } = default!;
    public List<Country> Countries { get; set; } = default!;
}
