using Grupp2.Services;
using Microsoft.OpenApi.Models;
using Grupp2.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<PlanetsMongoDBSettings>(builder.Configuration.GetSection("MongoDBPlanets"));
builder.Services.AddSingleton<PlanetMongoDBService>();

// Add services to the container.

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

// test


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
