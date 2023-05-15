﻿using GeoMastery.Persistence.Data;
using GeoMastery.Persistence.Exceptions;
using GeoMastery.Domain.Models;
using Microsoft.EntityFrameworkCore;
using GeoMastery.Persistence.Repositories.v1;
using SqliteWasmHelper;

namespace GeoMastery.BlazorWASM.Repositories.Local;

public class RegionHybridRepository : IRegionRepository
{
    private readonly ISqliteWasmDbContextFactory<CountryDbContext> _factory;
    public RegionHybridRepository(ISqliteWasmDbContextFactory<CountryDbContext> factory)
    {
        _factory = factory;
    }

    public async Task<List<Region>> GetAllRegionsAsync()
    {
        using var ctx = await _factory.CreateDbContextAsync();
        var regions = await ctx.Regions
            .OrderBy(r => r.Name)
            .ToListAsync();

        return regions;
    }
    public async Task<Region> GetRegionBySlugAsync(string slug)
    {
        using var ctx = await _factory.CreateDbContextAsync();
        var region = await ctx.Regions
            .FirstOrDefaultAsync(c => c.Slug == slug) ?? throw new NotFoundException($"Matching region not found for {slug}.");

        return region;
    }
}
