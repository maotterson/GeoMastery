﻿namespace GeoMastery.Domain.Models;
public class Country
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    public string? FlagBase64 { get; set; }
    public int Population { get; set; }
    public Guid CapitalId { get; set; }
    public City Capital { get; set; }
    public Guid ContinentId { get; set; }
    public Continent Continent { get; set; }
    public Guid RegionId { get; set; }
    public Region Region { get; set; }
}
