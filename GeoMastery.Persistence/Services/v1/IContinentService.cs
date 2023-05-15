using GeoMastery.Domain.Models;

namespace GeoMastery.Persistence.Services.v1;

public interface IContinentService
{
    Task<List<Continent>> GetAllContinentsAsync();
    Task<Continent> GetContinentBySlugAsync(string slug);
}
