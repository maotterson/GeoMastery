using GeoMastery.BlazorWASM.Data;
using GeoMastery.CountriesAPI.Middleware;
using GeoMastery.CountriesAPI.Repositories.v1;
using GeoMastery.CountriesAPI.Services.v1;
using GeoMastery.Persistence.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddPersistence();
builder.Services.AddScoped<ICountryRepository, CountryRepository>();
builder.Services.AddScoped<ICountryService, CountryService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Seed the database
using var scope = app.Services.CreateScope();
var scopedServices = scope.ServiceProvider;
var seeder = scopedServices.GetRequiredService<CountryDbSeeder>();
var seedDirectory = "SeedData";
seeder.SeedCountries(seedDirectory);

app.UseHttpsRedirection();

// Register middleware
app.UseMiddleware<ExceptionHandlerMiddleware>();
app.UseAuthorization();

app.MapControllers();
app.Run();
