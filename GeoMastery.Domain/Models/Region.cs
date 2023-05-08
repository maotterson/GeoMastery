namespace GeoMastery.Domain.Models;
public class Region
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public List<Country> Countries { get; set; }
}
