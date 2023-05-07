using GeoMastery.BlazorWASM;
using GeoMastery.BlazorWASM.Data;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddDbContext<CountryDbContext>();
builder.Services.AddTransient<CountryDbSeeder>();

// Build the host
var host = builder.Build();

// Seed the database
using (var scope = host.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var seeder = services.GetRequiredService<CountryDbSeeder>();
    seeder.SeedCountries();
}

await host.RunAsync();