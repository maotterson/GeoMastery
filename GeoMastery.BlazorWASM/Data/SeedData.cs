using GeoMastery.BlazorWASM.Data.Dto;
using GeoMastery.Domain.Models;
using System.Text.Json;

namespace GeoMastery.BlazorWASM.Data;

public static class SeedData
{
    public static void SeedCountries(CountryDbContext context)
    {
        if (context.Countries.Any())
        {
            return;
        }

        SeedCountryAbbreviation(context);
        SeedCountryCities(context);
        SeedCountryCapitals(context);
        SeedCountryContinents(context);
        SeedCountryFlags(context);
        SeedCountryPopulations(context);
        SeedCountryRegions(context);

        context.SaveChanges();
    }

    private static void SeedCountryAbbreviation(CountryDbContext context)
    {
        var countries = LoadJsonData<List<CountryAbbreviationSeedDto>>("abbreviations.json");
        foreach (var country in countries)
        {
            context.Countries.Add(new Country { Id = Guid.NewGuid(), Name = country.Country, Code = country.Abbreviation });
        }
    }

    private static void SeedCountryCities(CountryDbContext context)
    {
        var countries = LoadJsonData<List<CountryCitiesSeedDto>>("cities.json");
        foreach (var country in countries)
        {
            var existingCountry = context.Countries.SingleOrDefault(c => c.Name == country.Country);
            if (existingCountry != null)
            {
                var citiesToAdd = country.Cities.Select(cityName => new City { Id = Guid.NewGuid(), Name = cityName, Country = existingCountry, CountryId = existingCountry.Id }).ToList();
                context.Cities.AddRange(citiesToAdd);
            }
        }
    }
    private static void SeedCountryCapitals(CountryDbContext context)
    {
        var countries = LoadJsonData<List<CountryCapitalSeedDto>>("capitals.json");
        foreach (var country in countries)
        {
            var existingCountry = context.Countries.SingleOrDefault(c => c.Name == country.Country);
            var existingCity = context.Cities.SingleOrDefault(c => c.Name == c.Name && c.CountryId == existingCountry.Id); // this should both match name of city AND be the correct country
            if (existingCountry != null && existingCity != null) // todo: should eventually replace existingCity null check with creation of new entity
            {
                existingCountry.CapitalId = existingCity.Id;
            }
        }
    }
    private static void SeedCountryContinents(CountryDbContext context)
    {
        var countries = LoadJsonData<List<CountryContinentSeedDto>>("continents.json");
        foreach (var country in countries)
        {
            var existingCountry = context.Countries.SingleOrDefault(c => c.Name == country.Country);
            if (existingCountry != null)
            {
                // todo
            }
        }
    }
    private static void SeedCountryFlags(CountryDbContext context)
    {
        var countries = LoadJsonData<List<CountryFlagSeedDto>>("flags.json");
        foreach (var country in countries)
        {
            var existingCountry = context.Countries.SingleOrDefault(c => c.Name == country.Country);
            if (existingCountry != null)
            {
                // todo
            }
        }
    }
    private static void SeedCountryPopulations(CountryDbContext context)
    {
        var countries = LoadJsonData<List<CountryPopulationSeedDto>>("populations.json");
        foreach (var country in countries)
        {
            var existingCountry = context.Countries.SingleOrDefault(c => c.Name == country.Country);
            if (existingCountry != null)
            {
                // todo
            }
        }
    }
    private static void SeedCountryRegions(CountryDbContext context)
    {
        var countries = LoadJsonData<List<CountryRegionSeedDto>>("regions.json");
        foreach (var country in countries)
        {
            var existingCountry = context.Countries.SingleOrDefault(c => c.Name == country.Country);
            if (existingCountry != null)
            {
                // todo
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