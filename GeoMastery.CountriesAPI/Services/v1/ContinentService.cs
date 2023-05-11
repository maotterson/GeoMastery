using GeoMastery.CountriesAPI.Exceptions;
using GeoMastery.CountriesAPI.Repositories.v1;
using GeoMastery.Domain.Models;

namespace GeoMastery.CountriesAPI.Services.v1;

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

}
