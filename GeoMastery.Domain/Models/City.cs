namespace GeoMastery.Domain.Models;
public class City
{
    public int Id { get; set; }
    public Country Country { get; set; }
    public string Name { get; set; }
    public bool IsCapital { get; set; }
}
