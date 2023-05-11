using GeoMastery.BlazorWASM.Data;
using GeoMastery.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace GeoMastery.CountriesAPI.Repositories.v1;

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
            .ToListAsync();

        return continents;
    }

}
