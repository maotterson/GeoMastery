namespace GeoMastery.Domain.Models;
public class Country
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    public Guid CapitalId { get; set; }
    public List<City> Cities { get; set; }
}
