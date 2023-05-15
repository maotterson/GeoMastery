using GeoMastery.Domain.Models;

namespace GeoMastery.BlazorWASM.Repositories.Interfaces;

public interface IRegionWriteRepository
{
    Task AddRangeAsync(params Region[] regions);
}
