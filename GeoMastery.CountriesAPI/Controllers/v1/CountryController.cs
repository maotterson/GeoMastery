﻿using GeoMastery.Persistence.Data;
using GeoMastery.CountriesAPI.Contracts.Dto.v1;
using GeoMastery.CountriesAPI.Contracts.Extensions.v1;
using GeoMastery.Persistence.Services.v1;
using Microsoft.AspNetCore.Mvc;

namespace GeoMastery.CountriesAPI.Controllers.v1;
[ApiVersion("1.0")]
[Route("api/v1/[controller]")]
[ApiController]
public class CountryController : ControllerBase
{
    private readonly ICountryService _countryService;

    public CountryController(CountryDbContext context, ICountryService countryService)
    {
        _countryService = countryService;
    }

    // GET: api/v1/countries/by-region/{regionSlug}
    [HttpGet("by-region/{regionSlug}")]
    public async Task<ActionResult<IEnumerable<CountryDto>>> GetCountriesByRegion(string regionSlug)
    {
        var countries = await _countryService.GetCountriesByRegionAsync(regionSlug);
        return Ok(countries.ToDto());
    }

    // GET: api/v1/countries/by-continent/{continentSlug}
    [HttpGet("by-continent/{continentSlug}")]
    public async Task<ActionResult<IEnumerable<CountryDto>>> GetCountriesByContinent(string continentSlug)
    {
        var countries = await _countryService.GetCountriesByContinentAsync(continentSlug);
        return Ok(countries.ToDto());
    }
}
