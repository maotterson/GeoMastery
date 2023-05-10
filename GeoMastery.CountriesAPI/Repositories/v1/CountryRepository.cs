using GeoMastery.BlazorWASM.Data;
using GeoMastery.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace GeoMastery.CountriesAPI.Repositories.v1;

public class CountryRepository : ICountryRepository
{
    private readonly CountryDbContext _context;
    public CountryRepository(CountryDbContext dbContext)
    {
        _context = dbContext;
    }

    public async Task<List<Country>> GetCountriesByContinentAsync(Guid id)
    {
        var countries = await _context.Countries
            .Include(c => c.Region)
            .Include(c => c.Continent)
            .Include(c => c.Capital)
            .Where(c => c.ContinentId == id)
            .ToListAsync();

        return countries;
    }

    public async Task<List<Country>> GetCountriesByRegionAsync(Guid id)
    {
        var countries = await _context.Countries
           .Include(c => c.Region)
           .Include(c => c.Continent)
           .Include(c => c.Capital)
           .Where(c => c.RegionId == id)
           .ToListAsync();

        return countries;
    }
}
