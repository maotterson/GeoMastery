﻿using GeoMastery.BlazorWASM.Data;
using GeoMastery.CountriesAPI.Dto.v1;
using GeoMastery.CountriesAPI.Extensions.v1;
using GeoMastery.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GeoMastery.CountriesAPI.Controllers.v1;
[ApiVersion("1.0")]
[Route("api/v1/[controller]")]
[ApiController]
public class CountriesController : ControllerBase
{
    private readonly CountryDbContext _context;

    public CountriesController(CountryDbContext context)
    {
        _context = context;
    }

    // GET: api/v1/countries/by-region/{regionId}
    [HttpGet("by-region/{regionId}")]
    public async Task<ActionResult<IEnumerable<CountryDto>>> GetCountriesByRegion(Guid regionId)
    {
        var countries = await _context.Countries
            .Include(c => c.Region)
            .Include(c => c.Continent)
            .Include(c => c.Capital)
            .Where(c => c.RegionId == regionId)
            .ToListAsync();

        if (countries == null || countries.Count == 0)
        {
            return NotFound();
        }

        return Ok(countries.ToDto());
    }

    // GET: api/v1/countries/by-continent/{continentId}
    [HttpGet("by-continent/{continentId}")]
    public async Task<ActionResult<IEnumerable<CountryDto>>> GetCountriesByContinent(Guid continentId)
    {
        var countries = await _context.Countries
            .Include(c => c.Region)
            .Include(c => c.Continent)
            .Include(c => c.Capital)
            .Where(c => c.ContinentId == continentId)
            .ToListAsync();

        if (countries == null || countries.Count == 0)
        {
            return NotFound();
        }

        return Ok(countries.ToDto());
    }
}
