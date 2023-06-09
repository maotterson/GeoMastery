﻿using GeoMastery.BlazorWASM.Extensions;
using GeoMastery.CountriesAPI.Contracts.Dto.v1;
using GeoMastery.Domain.Models;
using GeoMastery.Persistence.Exceptions;
using GeoMastery.Persistence.Repositories.v1;
using System.Net.Http.Json;

namespace GeoMastery.BlazorWASM.Repositories.ApiClient;

public class ContinentApiClient : IContinentRepository
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;
    public ContinentApiClient(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;  
        _configuration = configuration;
    }
    public async Task<List<Continent>> GetAllContinentsAsync()
    {
        var baseUrl = _configuration["CountriesApi:BaseUrl"];
        var requestUrl = baseUrl + "continent";
        
        var continents = await _httpClient.GetFromJsonAsync<List<ContinentDto>>(requestUrl);

        if (continents is null) throw new NotFoundException("No continents found.");

        return continents.ToContinents();
    }

    public async Task<Continent> GetContinentBySlugAsync(string slug)
    {
        var baseUrl = _configuration["CountriesApi:BaseUrl"];
        var requestUrl = baseUrl + $"continent/{slug}";

        var continent = await _httpClient.GetFromJsonAsync<ContinentDto>(requestUrl);

        if (continent is null) throw new NotFoundException($"Continent with slug {slug} not found.");

        return continent.ToContinent();
    }
}
