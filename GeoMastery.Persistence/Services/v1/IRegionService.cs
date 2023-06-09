﻿using GeoMastery.Domain.Models;

namespace GeoMastery.Persistence.Services.v1;

public interface IRegionService
{
    Task<List<Region>> GetAllRegionsAsync();
    Task<Region> GetRegionBySlugAsync(string slug);
}
