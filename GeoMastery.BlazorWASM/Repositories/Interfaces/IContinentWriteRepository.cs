using GeoMastery.Domain.Models;

namespace GeoMastery.BlazorWASM.Repositories.Interfaces;

public interface IContinentWriteRepository
{
    Task AddRangeAsync(params Continent[] continents);
}
