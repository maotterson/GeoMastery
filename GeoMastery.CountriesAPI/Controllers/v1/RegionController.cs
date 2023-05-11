﻿using GeoMastery.BlazorWASM.Data;
using GeoMastery.CountriesAPI.Dto.v1;
using GeoMastery.CountriesAPI.Extensions.v1;
using GeoMastery.CountriesAPI.Services.v1;
using Microsoft.AspNetCore.Mvc;

namespace GeoMastery.CountriesAPI.Controllers.v1;
[ApiVersion("1.0")]
[Route("api/v1/[controller]")]
[ApiController]
public class RegionController : ControllerBase
{
    private readonly IRegionService _regionService;

    public RegionController(CountryDbContext context, IRegionService regionService)
    {
        _regionService = regionService;
    }

    // GET: api/v1/regions/
    [HttpGet("")]
    public async Task<ActionResult<IEnumerable<RegionDto>>> GetAllRegions()
    {
        var regions = await _regionService.GetAllRegions();
        return Ok(regions.ToDto());
    }
}