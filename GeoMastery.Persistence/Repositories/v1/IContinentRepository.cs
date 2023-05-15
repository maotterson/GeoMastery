using GeoMastery.Domain.Models;

namespace GeoMastery.Persistence.Repositories.v1;

public interface IContinentRepository
{
    Task<List<Continent>> GetAllContinentsAsync();
    Task<Continent> GetContinentBySlugAsync(string slug);
}
