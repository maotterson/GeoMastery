using GeoMastery.BlazorWASM.Data;
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
            .ToListAsync();

        return regions;
    }

}
