using GeoMastery.BlazorWASM.Data.Dto;
using GeoMastery.Domain.Models;
using System.Text.Json;

namespace GeoMastery.BlazorWASM.Data;

public class CountryDbSeeder
{
    private readonly CountryDbContext _context;
    public void SeedCountries()
    {
        try
        {
            Console.WriteLine("preparing to seed countries");
            if (_context.Countries.Any())
            {
                Console.WriteLine("countries exist");
                return;
            }
            Console.WriteLine("countries dont exist, seeding now");

            SeedCountryAbbreviation();
            Console.WriteLine("seeded 1");
            SeedCountryCities();
            Console.WriteLine("seeded 2");
            SeedCountryCapitals();
            Console.WriteLine("seeded 3");
            SeedCountryContinents();
            Console.WriteLine("seeded 4");
            SeedCountryFlags();
            Console.WriteLine("seeded 5");
            SeedCountryPopulations();
            Console.WriteLine("seeded 6");
            SeedCountryRegions();
            Console.WriteLine("seeded 7");

            _context.SaveChanges();
            Console.WriteLine("saved changes");
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

    private void SeedCountryAbbreviation()
    {
        Console.WriteLine("loading json");
        var countries = LoadJsonData<List<CountryAbbreviationSeedDto>>("abbreviations.json");
        Console.WriteLine("loaded json");
        foreach (var country in countries)
        {
            Console.WriteLine("adding country: " + country.Country + " " + country.Abbreviation);
            _context.Countries.Add(new Country { Id = Guid.NewGuid(), Name = country.Country, Code = country.Abbreviation });
        }
    }

    private void SeedCountryCities()
    {
        var countries = LoadJsonData<List<CountryCitiesSeedDto>>("cities.json");
        foreach (var country in countries)
        {
            var existingCountry = _context.Countries.SingleOrDefault(c => c.Name == country.Country);
            if (existingCountry != null)
            {
                var citiesToAdd = country.Cities.Select(cityName => new City { Id = Guid.NewGuid(), Name = cityName, Country = existingCountry, CountryId = existingCountry.Id }).ToList();
                _context.Cities.AddRange(citiesToAdd);
            }
        }
    }
    private void SeedCountryCapitals()
    {
        var countries = LoadJsonData<List<CountryCapitalSeedDto>>("capitals.json");
        foreach (var country in countries)
        {
            var existingCountry = _context.Countries.SingleOrDefault(c => c.Name == country.Country);
            var existingCity = _context.Cities.SingleOrDefault(c => c.Name == c.Name && c.CountryId == existingCountry.Id); // this should both match name of city AND be the correct country
            if (existingCountry != null && existingCity != null) // todo: should eventually replace existingCity null check with creation of new entity
            {
                existingCountry.CapitalId = existingCity.Id;
            }
        }
    }
    private void SeedCountryContinents()
    {
        var countries = LoadJsonData<List<CountryContinentSeedDto>>("continents.json");
        foreach (var country in countries)
        {
            var existingCountry = _context.Countries.SingleOrDefault(c => c.Name == country.Country);
            if (existingCountry != null)
            {
                var existingContinent = _context.Continents.SingleOrDefault(c => c.Name == country.Continent);
                if (existingContinent is null)
                {
                    existingContinent = new Continent { Name = country.Continent, Id = Guid.NewGuid() };
                    _context.Continents.Add(existingContinent);
                }
                existingCountry.Continent = existingContinent;
                existingCountry.ContinentId = existingContinent.Id;
            }
        }
    }
    private void SeedCountryFlags()
    {
        var countries = LoadJsonData<List<CountryFlagSeedDto>>("flags.json");
        foreach (var country in countries)
        {
            var existingCountry = _context.Countries.SingleOrDefault(c => c.Name == country.Country);
            if (existingCountry != null)
            {
                existingCountry.FlagBase64 = country.FlagBase64;
            }
        }
    }
    private void SeedCountryPopulations()
    {
        var countries = LoadJsonData<List<CountryPopulationSeedDto>>("populations.json");
        foreach (var country in countries)
        {
            var existingCountry = _context.Countries.SingleOrDefault(c => c.Name == country.Country);
            if (existingCountry != null)
            {
                if (int.TryParse(country.Population, out int population))
                {
                    existingCountry.Population = population;
                }
                else
                {
                    existingCountry.Population = 0; // some fields may be null, may need to adjust this depending on how it appears
                }
            }
        }
    }
    private void SeedCountryRegions()
    {
        var countries = LoadJsonData<List<CountryRegionSeedDto>>("regions.json");
        foreach (var country in countries)
        {
            var existingCountry = _context.Countries.SingleOrDefault(c => c.Name == country.Country);
            if (existingCountry != null)
            {
                var existingRegion = _context.Regions.SingleOrDefault(c => c.Name == country.Location);
                if (existingRegion is null)
                {
                    existingRegion = new Region { Name = country.Location, Id = Guid.NewGuid() };
                    _context.Regions.Add(existingRegion);
                }
                existingCountry.Region = existingRegion;
                existingCountry.RegionId = existingRegion.Id;
            }
        }
    }

    private static T LoadJsonData<T>(string fileName)
    {
        using (var file = File.OpenText(fileName))
        {
            var json = file.ReadToEnd();
            return JsonSerializer.Deserialize<T>(json);
        }
    }
}