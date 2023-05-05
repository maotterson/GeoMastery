namespace GeoMastery.Domain.Models;
public class Country
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    public int CapitalId { get; set; }
    public List<City> Cities { get; set; }
}
