using GeoMastery.Persistence.Exceptions;
using GeoMastery.Persistence.Repositories.v1;
using GeoMastery.Domain.Models;

namespace GeoMastery.Persistence.Services.v1;

public class ContinentService : IContinentService
{
    private IContinentRepository _continentRepository;
    public ContinentService(IContinentRepository continentRepository)
    {
        _continentRepository = continentRepository;
    }
    public async Task<List<Continent>> GetAllContinentsAsync()
    {
        var continents = await _continentRepository.GetAllContinentsAsync();
        return continents;
    }
    public async Task<Continent> GetContinentBySlugAsync(string slug)
    {
        var region = await _continentRepository.GetContinentBySlugAsync(slug);
        return region;
    }

}
