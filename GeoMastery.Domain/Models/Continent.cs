namespace GeoMastery.Domain.Models;
public class Continent
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Slug { get; set; }
    public List<Country> Countries { get; set; }
}
