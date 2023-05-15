using GeoMastery.Domain.Models;

namespace GeoMastery.BlazorWASM.Repositories.Interfaces;

public interface ICountryWriteRepository
{
    Task AddRangeAsync(params Country[] countries);
}
