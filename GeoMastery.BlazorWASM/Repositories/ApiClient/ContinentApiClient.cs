using GeoMastery.Domain.Models;
using GeoMastery.Persistence.Repositories.v1;

namespace GeoMastery.BlazorWASM.Repositories.ApiClient;

public class ContinentApiClient : IContinentRepository
{
    public Task<List<Continent>> GetAllContinentsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Continent> GetContinentBySlugAsync(string slug)
    {
        throw new NotImplementedException();
    }
}
