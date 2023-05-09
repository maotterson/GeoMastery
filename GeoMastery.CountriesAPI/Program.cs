using GeoMastery.BlazorWASM.Data;
using GeoMastery.Persistence.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddPersistence();

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

app.UseAuthorization();

app.MapControllers();

app.Run();
