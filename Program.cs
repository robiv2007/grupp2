using Grupp2.Models;
using Grupp2.Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<InspectionDBSettings>(builder.Configuration.GetSection("TrainingDB"));
builder.Services.AddSingleton<InspectionsDBService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen( options => {
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
