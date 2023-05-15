using GeoMastery.Persistence.Data;
using GeoMastery.Persistence.Exceptions;
using GeoMastery.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace GeoMastery.Persistence.Repositories.v1;

public class ContinentRepository : IContinentRepository
{
    private readonly CountryDbContext _context;
    public ContinentRepository(CountryDbContext dbContext)
    {
        _context = dbContext;
    }

    public async Task<List<Continent>> GetAllContinentsAsync()
    {
        var continents = await _context.Continents
            .OrderBy(c => c.Name)
            .ToListAsync();

        return continents;
    }

    public async Task<Continent> GetContinentBySlugAsync(string slug)
    {
        var continent = await _context.Continents
            .FirstOrDefaultAsync(c => c.Slug == slug) ?? throw new NotFoundException($"Matching continent not found for {slug}.");

        return continent;
    }
}
