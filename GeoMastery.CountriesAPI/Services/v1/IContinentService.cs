using GeoMastery.Domain.Models;

namespace GeoMastery.CountriesAPI.Services.v1;

public interface IContinentService
{
    Task<List<Continent>> GetAllContinentsAsync();
}
