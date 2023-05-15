using GeoMastery.Persistence.Data;
using GeoMastery.Persistence.Exceptions;
using GeoMastery.Domain.Models;
using Microsoft.EntityFrameworkCore;
using GeoMastery.Persistence.Repositories.v1;
using SqliteWasmHelper;
using GeoMastery.BlazorWASM.Repositories.ApiClient;

namespace GeoMastery.BlazorWASM.Repositories.Local;

public class ContinentHybridRepository : IContinentRepository
{
    private readonly ContinentLocalRepository _localRepository;
    private readonly ContinentApiClient _apiClient;
    public ContinentHybridRepository(ContinentLocalRepository local, ContinentApiClient apiClient)
    {
        _localRepository = local;
        _apiClient = apiClient;
    }

    public async Task<List<Continent>> GetAllContinentsAsync()
    {
        var continents = await _localRepository.GetAllContinentsAsync();
        if (continents.Any())
        {
            return continents;
        }
        continents = await _apiClient.GetAllContinentsAsync();
        await _localRepository.AddRangeAsync(continents.ToArray());
        return continents;
    }

    public async Task<Continent> GetContinentBySlugAsync(string slug)
    {
        return await _localRepository.GetContinentBySlugAsync(slug);
    }
}
