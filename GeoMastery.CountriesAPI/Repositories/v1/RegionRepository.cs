using GeoMastery.BlazorWASM.Data;
using GeoMastery.CountriesAPI.Exceptions;
using GeoMastery.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace GeoMastery.CountriesAPI.Repositories.v1;

public class RegionRepository : IRegionRepository
{
    private readonly CountryDbContext _context;
    public RegionRepository(CountryDbContext dbContext)
    {
        _context = dbContext;
    }

    public async Task<List<Region>> GetAllRegionsAsync()
    {
        var regions = await _context.Regions
            .OrderBy(r => r.Name)
            .ToListAsync();

        return regions;
    }
    public async Task<Region> GetRegionBySlugAsync(string slug)
    {
        var region = await _context.Regions
            .FirstOrDefaultAsync(c => c.Slug == slug) ?? throw new NotFoundException($"Matching region not found for {slug}.");

        return region;
    }
}
