namespace GeoMastery.Domain.Models;
public class Country
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    public Guid CapitalId { get; set; }
    public City Capital { get; set; }
    public Guid ContinentId { get; set; }
    public Continent Continent { get; set; }
    public Guid RegionId { get; set; }
    public Region Region { get; set; }
    public List<City> Cities { get; set; }
}
