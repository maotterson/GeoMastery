namespace GeoMastery.Domain.Models;
public class Continent
{
    public Guid Id { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string Slug { get; set; } = default!;
    public List<Country> Countries { get; set; } = default!;
}
