using GeoMastery.BlazorWASM;
using GeoMastery.BlazorWASM.Services;
using GeoMastery.BlazorWASM.State;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<ICountriesService, CountriesService>();
builder.Services.AddSingleton<PageHistoryState>();


// Build the hostS
var host = builder.Build();
await host.RunAsync();