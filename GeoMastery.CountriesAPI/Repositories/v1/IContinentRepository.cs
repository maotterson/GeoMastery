using GeoMastery.Domain.Models;

namespace GeoMastery.CountriesAPI.Repositories.v1;

public interface IContinentRepository
{
    Task<List<Continent>> GetAllContinentsAsync();
}
