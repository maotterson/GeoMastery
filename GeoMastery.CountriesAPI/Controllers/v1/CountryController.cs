using GeoMastery.BlazorWASM.Data;
using GeoMastery.CountriesAPI.Dto.v1;
using GeoMastery.CountriesAPI.Extensions.v1;
using GeoMastery.CountriesAPI.Services.v1;
using GeoMastery.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GeoMastery.CountriesAPI.Controllers.v1;
[ApiVersion("1.0")]
[Route("api/v1/[controller]")]
[ApiController]
public class CountryController : ControllerBase
{
    private readonly CountryDbContext _context;
    private readonly ICountryService _countryService;

    public CountryController(CountryDbContext context, ICountryService countryService)
    {
        _context = context;
        _countryService = countryService;
    }

    // GET: api/v1/countries/by-region/{regionId}
    [HttpGet("by-region/{regionId}")]
    public async Task<ActionResult<IEnumerable<CountryDto>>> GetCountriesByRegion(string regionSlug)
    {
        var countries = await _countryService.GetCountriesByRegionAsync(regionSlug);
        return Ok(countries.ToDto());
    }

    // GET: api/v1/countries/by-continent/{continentId}
    [HttpGet("by-continent/{continentId}")]
    public async Task<ActionResult<IEnumerable<CountryDto>>> GetCountriesByContinent(string continentSlug)
    {
        var countries = await _countryService.GetCountriesByRegionAsync(continentSlug);
        return Ok(countries.ToDto());
    }
}
