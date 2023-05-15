using GeoMastery.BlazorWASM;
using GeoMastery.Persistence.Data;
using GeoMastery.Persistence.Repositories.v1;
using GeoMastery.Persistence.Services.v1;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.EntityFrameworkCore;
using SqliteWasmHelper;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Register persistence/application layers
builder.Services.AddScoped<ICountryService, CountryService>();
builder.Services.AddScoped<ICountryRepository, CountryRepository>();
builder.Services.AddScoped<IContinentService, ContinentService>();
builder.Services.AddScoped<IContinentRepository, ContinentRepository>();
builder.Services.AddScoped<IRegionService, RegionService>();
builder.Services.AddScoped<IRegionRepository, RegionRepository>();

// Add context factory
builder.Services.AddSqliteWasmDbContextFactory<CountryDbContext>(
    opts => opts.UseSqlite("Data Source=countries.sqlite3"));

// Build the host
var host = builder.Build();

// Get ctx factory
var factory = host.Services.GetRequiredService<ISqliteWasmDbContextFactory<CountryDbContext>>();
using var ctx = await factory.CreateDbContextAsync();
var seeder = new CountryDbSeeder(ctx);
seeder.SeedCountries("sample-data");

await host.RunAsync();

