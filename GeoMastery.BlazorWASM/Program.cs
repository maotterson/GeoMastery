using GeoMastery.BlazorWASM;
using GeoMastery.BlazorWASM.Config;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Configuration.AddJsonFile("appsettings.json");


builder.Services.Configure<ApiConfig>(config =>
{
    config.CountriesApiBaseUrl = builder.Configuration.GetSection("ApiConfig:CountriesApiBaseUrl")!.Value!;
});


// Build the host
var host = builder.Build();
await host.RunAsync();