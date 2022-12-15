using Grupp2.Models;
using Grupp2.Services;
using System.Reflection;
using Microsoft.OpenApi.Models;

// Add services to the container.

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

// Malcolms
builder.Services.Configure<RestaurantMongoDBSettings>(builder.Configuration.GetSection("RestaurantMongoDB"));
builder.Services.AddSingleton<RestaurantMongoDBService>();



builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();



builder.Services.AddSwaggerGen(options =>
{

    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Group 2 API",
        Description = "School project in AU21 from ItHögskolan Stockholm",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "John Doe",
            Url = new Uri("https://johndoe.com/contact")
        }
    });

      var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";

    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
}
);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();