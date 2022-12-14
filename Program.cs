
using Grupp2.Models;
using Grupp2.Services;
using System.Reflection;
using Microsoft.OpenApi.Models;



var builder = WebApplication.CreateBuilder(args);


// Zainab
builder.Services.Configure<RoutesMongoDBSettings>(builder.Configuration.GetSection("RoutesMongoDB"));
builder.Services.AddSingleton<RoutesMongoDBService>();

// Roberts
builder.Services.Configure<PlanetsMongoDBSettings>(builder.Configuration.GetSection("MongoDBPlanets"));
builder.Services.AddSingleton<PlanetMongoDBService>();

// Susannas
builder.Services.Configure<InspectionDBSettings>(builder.Configuration.GetSection("TrainingDB"));
builder.Services.AddSingleton<InspectionsDBService>();

// Tonis
builder.Services.Configure<ThoughtsDatabaseSettings>(
builder.Configuration.GetSection("ThoughtsMongoDB"));
builder.Services.AddSingleton<ThoughtService>();



builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
}
);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
