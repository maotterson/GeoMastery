using GeoMastery.BlazorWASM.Data;
using GeoMastery.CountriesAPI.Contracts.Dto.v1;
using GeoMastery.CountriesAPI.Extensions.v1;
using GeoMastery.CountriesAPI.Services.v1;
using Microsoft.AspNetCore.Mvc;

namespace GeoMastery.CountriesAPI.Controllers.v1;
[ApiVersion("1.0")]
[Route("api/v1/[controller]")]
[ApiController]
public class ContinentController : ControllerBase
{
    private readonly IContinentService _continentService;

    public ContinentController(CountryDbContext context, IContinentService continentService)
    {
        _continentService = continentService;
    }

    // GET: api/v1/continents/
    [HttpGet("")]
    public async Task<ActionResult<IEnumerable<ContinentDto>>> GetAllContinents()
    {
        var continents = await _continentService.GetAllContinentsAsync();
        return Ok(continents.ToDto());
    }

    // GET: api/v1/continents/by-slug/{slug}
    [HttpGet("by-slug/{slug}")]
    public async Task<ActionResult<ContinentDto>> GetContinentBySlug(string slug)
    {
        var continent = await _continentService.GetContinentBySlugAsync(slug);
        return Ok(continent.ToDto());
    }
}
