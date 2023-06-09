using GeoMastery.Persistence.Data;
using GeoMastery.CountriesAPI.Middleware;
using GeoMastery.Persistence.Repositories.v1;
using GeoMastery.Persistence.Services.v1;
using GeoMastery.Persistence.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddPersistence();
builder.Services.AddScoped<ICountryRepository, CountryRepository>();
builder.Services.AddScoped<ICountryService, CountryService>();
builder.Services.AddScoped<IRegionRepository, RegionRepository>();
builder.Services.AddScoped<IRegionService, RegionService>();
builder.Services.AddScoped<IContinentRepository, ContinentRepository>();
builder.Services.AddScoped<IContinentService, ContinentService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Define Cors policy
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

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
app.UseCors();
app.UseAuthorization();

app.MapControllers();
app.Run();
