using GeoMastery.Persistence.Data.Dto;
using GeoMastery.Domain.Models;
using GeoMastery.Domain.Utilities;
using System.Text.Json;
using GeoMastery.Persistence.Data;

namespace GeoMastery.BlazorWASM.Services;

public class HttpCountryDbSeeder
{
    private readonly HttpClient _http;
    private readonly CountryDbContext _context;
    public async Task SeedCountries(string url)
    {
        try
        {
            _context.Database.EnsureCreated();
            if (_context.Countries.Any())
            {
                return;
            }

            await SeedCountryAbbreviation(url);
            await SeedCountryCapitalsWithoutCities(url);
            await SeedCountryContinents(url);
            await SeedCountryFlags(url);
            await SeedCountryPopulations(url);
            await SeedCountryRegions(url);
            SeedMissingData();

            _context.SaveChanges();
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        
    }

    public HttpCountryDbSeeder(CountryDbContext context, HttpClient http)
    {
        _context = context;
        _http = http;
    }

    private async Task SeedCountryAbbreviation(string url)
    {
        var countries = await LoadJsonData<List<CountryAbbreviationSeedDto>>(url + "/abbreviations.json");
        foreach (var country in countries)
        {
            _context.Countries.Add(new Country 
            {   
                Id = Guid.NewGuid(), 
                Name = country.Country, 
                Slug = StringUtilities.Slugify(country.Country),
                Code = country.Abbreviation });
        }
    }

    private async Task SeedCountryCapitalsWithoutCities(string url)
    {
        var countries = await LoadJsonData<List<CountryCapitalSeedDto>>(url + "/capitals.json");
        foreach (var country in countries)
        {
            var existingCountry = _context.Countries.Local.SingleOrDefault(c => c.Name == country.Country);
            if (existingCountry != null)
            {
                if (country.Capital is null)
                {
                    continue;
                }
                var capitalToAddAsCity = new City 
                { 
                    Id = Guid.NewGuid(), 
                    Name = country.Capital, 
                    Country = existingCountry, 
                    CountryId = existingCountry.Id };

                _context.Cities.Add(capitalToAddAsCity);
                existingCountry.CapitalId = capitalToAddAsCity.Id;
            }
        }
    }
    private async Task SeedCountryContinents(string url)
    {
        var countries = await LoadJsonData<List<CountryContinentSeedDto>>(url + "/continents.json");
        foreach (var country in countries)
        {
            var existingCountry = _context.Countries.Local.SingleOrDefault(c => c.Name == country.Country);
            if (existingCountry != null)
            {
                if (country.Continent is null)
                {
                    country.Continent = "N/A";
                }
                var existingContinent = _context.Continents.Local.SingleOrDefault(c => c.Name == country.Continent);
                if (existingContinent is null)
                {
                    existingContinent = new Continent 
                    {
                        Id = Guid.NewGuid(),
                        Name = country.Continent,
                        Slug = StringUtilities.Slugify(country.Continent)
                    };
                    _context.Continents.Add(existingContinent);
                }
                existingCountry.Continent = existingContinent;
                existingCountry.ContinentId = existingContinent.Id;
            }
        }
    }
    private async Task SeedCountryFlags(string url)
    {
        var countries = await LoadJsonData<List<CountryFlagSeedDto>>(url + "/flags.json");
        foreach (var country in countries)
        {
            var existingCountry = _context.Countries.Local.SingleOrDefault(c => c.Name == country.Country);
            if (existingCountry != null)
            {
                existingCountry.FlagBase64 = country.FlagBase64;
            }
        }
    }
    private async Task SeedCountryPopulations(string url)
    {
        var countries = await LoadJsonData<List<CountryPopulationSeedDto>>(url + "/populations.json");
        foreach (var country in countries)
        {
            var existingCountry = _context.Countries.Local.SingleOrDefault(c => c.Name == country.Country);
            if (existingCountry != null)
            {
                existingCountry.Population = country.Population;
            }
        }
    }
    private async Task SeedCountryRegions(string url)
    {
        var countries = await LoadJsonData<List<CountryRegionSeedDto>>(url + "/regions.json");
        foreach (var country in countries)
        {
            var existingCountry = _context.Countries.Local.SingleOrDefault(c => c.Name == country.Country);
            if (existingCountry != null)
            {
                if (country.Location is null)
                {
                    country.Location = "N/A";
                }
                var existingRegion = _context.Regions.Local.SingleOrDefault(c => c.Name == country.Location);
                if (existingRegion is null)
                {
                    existingRegion = new Region
                    {
                        Id = Guid.NewGuid(),
                        Name = country.Location, 
                        Slug = StringUtilities.Slugify(country.Location)
                    };
                    _context.Regions.Add(existingRegion);
                }
                existingCountry.Region = existingRegion;
                existingCountry.RegionId = existingRegion.Id;
            }
        }
    }
    private void SeedMissingData()
    {
        var missingContinent = _context.Continents.Local.SingleOrDefault(c => c.Name == "N/A") 
            ?? new Continent 
            { 
                Id = Guid.NewGuid(), 
                Name = "N/A",
                Slug = StringUtilities.Slugify("N/A")
            };
        var missingRegion = _context.Regions.Local.SingleOrDefault(c => c.Name == "N/A") 
            ?? new Region 
            { 
                Id = Guid.NewGuid(), 
                Name = "N/A",
                Slug = StringUtilities.Slugify("N/A")
            };
        _context.Continents.Add(missingContinent);
        _context.Regions.Add(missingRegion);
        foreach (var c in _context.Countries.Local)
        {
            if (c.Continent == null)
            {
                SeedMissingFieldWith(c, missingContinent);
            }
            if (c.Region == null)
            {
                SeedMissingFieldWith(c, missingRegion);
            }
        }
    }
    private void SeedMissingFieldWith<T>(Country c, T missingType)
    {
        if (missingType is Continent continent)
        {
            c.Continent = continent;
            c.ContinentId = continent.Id;
            return;
        }
        if (missingType is Region region)
        {
            c.Region = region;
            c.RegionId = region.Id;
            return;
        }
        throw new ArgumentException("Missing type must be of type Continent or Region", nameof(missingType));
    }

    private async Task<T> LoadJsonData<T>(string url)
    {
        var json = await _http.GetStringAsync(url);
        return JsonSerializer.Deserialize<T>(json)!;
    }
}