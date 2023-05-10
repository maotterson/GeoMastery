using GeoMastery.BlazorWASM.Data.Dto;
using GeoMastery.Domain.Models;
using GeoMastery.Domain.Utilities;
using System.Text.Json;

namespace GeoMastery.BlazorWASM.Data;

public class CountryDbSeeder
{
    private readonly CountryDbContext _context;
    public void SeedCountries(string directory)
    {
        try
        {
            _context.Database.EnsureCreated();
            if (_context.Countries.Any())
            {
                return;
            }

            SeedCountryAbbreviation(directory);
            SeedCountryCapitalsWithoutCities(directory);
            SeedCountryContinents(directory);
            SeedCountryFlags(directory);
            SeedCountryPopulations(directory);
            SeedCountryRegions(directory);
            SeedMissingData();

            _context.SaveChanges();
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        
    }

    public CountryDbSeeder(CountryDbContext context)
    {
        _context = context;
    }

    private void SeedCountryAbbreviation(string directory)
    {
        var countries = LoadJsonData<List<CountryAbbreviationSeedDto>>(directory + "/abbreviations.json");
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

    private void SeedCountryCapitalsWithoutCities(string directory)
    {
        var countries = LoadJsonData<List<CountryCapitalSeedDto>>(directory + "/capitals.json");
        foreach (var country in countries)
        {
            var existingCountry = _context.Countries.Local.SingleOrDefault(c => c.Name == country.Country);
            if (existingCountry != null)
            {
                if (country.Capital is null)
                {
                    country.Capital = "N/A";
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
    private void SeedCountryContinents(string directory)
    {
        var countries = LoadJsonData<List<CountryContinentSeedDto>>(directory + "/continents.json");
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
    private void SeedCountryFlags(string directory)
    {
        var countries = LoadJsonData<List<CountryFlagSeedDto>>(directory + "/flags.json");
        foreach (var country in countries)
        {
            var existingCountry = _context.Countries.Local.SingleOrDefault(c => c.Name == country.Country);
            if (existingCountry != null)
            {
                existingCountry.FlagBase64 = country.FlagBase64;
            }
        }
    }
    private void SeedCountryPopulations(string directory)
    {
        var countries = LoadJsonData<List<CountryPopulationSeedDto>>(directory + "/populations.json");
        foreach (var country in countries)
        {
            var existingCountry = _context.Countries.Local.SingleOrDefault(c => c.Name == country.Country);
            if (existingCountry != null)
            {
                existingCountry.Population = country.Population;
            }
        }
    }
    private void SeedCountryRegions(string directory)
    {
        var countries = LoadJsonData<List<CountryRegionSeedDto>>(directory + "/regions.json");
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

    private static T LoadJsonData<T>(string fileName)
    {
        using (var file = File.OpenText(fileName))
        {
            var json = file.ReadToEnd();
            return JsonSerializer.Deserialize<T>(json);
        }
    }

    // currently deprecated, cities.json data file would need to be pruned because it currently doesn't include data that would be relevant
    private void SeedCountryCities(string directory)
    {
        var countries = LoadJsonData<List<CountryCitiesSeedDto>>(directory + "/cities.json");
        foreach (var country in countries)
        {
            var existingCountry = _context.Countries.Local.SingleOrDefault(c => c.Name == country.Country);
            if (existingCountry != null)
            {
                var citiesToAdd = country.Cities.Select(cityName => new City { Id = Guid.NewGuid(), Name = cityName, Country = existingCountry, CountryId = existingCountry.Id }).ToList();
                _context.Cities.AddRange(citiesToAdd);
            }
        }
    }
    // currently deprecated, cities.json data file would need to be pruned because it currently doesn't include data that would be relevant
    private void SeedCountryCapitalsWithCities(string directory)
    {
        var countries = LoadJsonData<List<CountryCapitalSeedDto>>(directory + "/capitals.json");
        foreach (var country in countries)
        {
            var existingCountry = _context.Countries.Local.SingleOrDefault(c => c.Name == country.Country);
            var existingCity = _context.Cities.Local.SingleOrDefault(c => c.Name == c.Name && c.CountryId == existingCountry.Id); // this should both match name of city AND be the correct country
            if (existingCountry != null && existingCity != null) // todo: should eventually replace existingCity null check with creation of new entity
            {
                existingCountry.CapitalId = existingCity.Id;
            }
        }
    }
}