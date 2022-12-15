
using Grupp2.Models;
using Grupp2.Services;
using System.Reflection;
using Microsoft.OpenApi.Models;


// Creates a new webbapplication builder that will give us access to configuration and functionallity
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
// Register a instance of ThoughtsDatabaseSettings and get the section THoughtsMongoDB from the appsettings.json file
builder.Services.Configure<ThoughtsDatabaseSettings>(
builder.Configuration.GetSection("ThoughtsMongoDB"));
// Create a singelton of the ThoughtService so that we can send it in to the controller
builder.Services.AddSingleton<ThoughtService>();


// Create our controllers
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();


// Add swagger to provide the frontend with an interface to test the functionality
builder.Services.AddSwaggerGen(options =>
{

    // Create document  with information about the database and som contact info
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

// Build our app
var app = builder.Build();

// If the app is in development stage, use swagger ui for testing
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    // Add to automaticly go to the swagger ui when you click the link
    options.RoutePrefix = string.Empty;
});
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// Run our app
app.Run();