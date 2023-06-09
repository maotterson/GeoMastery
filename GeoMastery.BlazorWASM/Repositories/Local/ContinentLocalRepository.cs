﻿using GeoMastery.Persistence.Data;
using GeoMastery.Persistence.Exceptions;
using GeoMastery.Domain.Models;
using Microsoft.EntityFrameworkCore;
using GeoMastery.Persistence.Repositories.v1;
using SqliteWasmHelper;
using GeoMastery.BlazorWASM.Repositories.Interfaces;

namespace GeoMastery.BlazorWASM.Repositories.Local;

public class ContinentLocalRepository : IContinentRepository, IContinentWriteRepository
{
    private readonly ISqliteWasmDbContextFactory<CountryDbContext> _factory;
    public ContinentLocalRepository(ISqliteWasmDbContextFactory<CountryDbContext> factory)
    {
        _factory = factory;
    }

    public async Task<List<Continent>> GetAllContinentsAsync()
    {
        using var ctx = await _factory.CreateDbContextAsync();
        var continents = await ctx.Continents
            .OrderBy(c => c.Name)
            .ToListAsync();

        return continents;
    }

    public async Task<Continent> GetContinentBySlugAsync(string slug)
    {
        using var ctx = await _factory.CreateDbContextAsync();
        var continent = await ctx.Continents
            .FirstOrDefaultAsync(c => c.Slug == slug) ?? throw new NotFoundException($"Matching continent not found for {slug}.");

        return continent;
    }

    public async Task AddRangeAsync(params Continent[] continents)
    {
        using var ctx = await _factory.CreateDbContextAsync();
        await ctx.Continents.AddRangeAsync(continents);
        await ctx.SaveChangesAsync();
    }

}
