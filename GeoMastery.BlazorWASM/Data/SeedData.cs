using GeoMastery.BlazorWASM.Dto;
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

        context.SaveChanges();
    }

    private static void SeedCountryAbbreviation(CountryDbContext context)
    {
        var countries = LoadJsonData<List<CountryAbbreviationJsonDto>>("abbreviations.json");
        foreach (var country in countries)
        {
            context.Countries.Add(new Country { Id = Guid.NewGuid(), Name = country.Country, Code = country.Abbreviation });
        }
    }

    private static void SeedCountryCities(CountryDbContext context)
    {
        var countries = LoadJsonData<List<CountryCitiesJsonDto>>("cities.json");
        foreach (var country in countries)
        {
            var existingCountry = context.Countries.SingleOrDefault(c => c.Name == country.Country);
            if (existingCountry != null)
            {
                existingCountry.Cities = country.Cities.Select(cityName => new City { Id = Guid.NewGuid(), Name = cityName, Country = existingCountry, CountryId = existingCountry.Id }).ToList();
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