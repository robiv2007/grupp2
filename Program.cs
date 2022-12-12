using Grupp2.Models;
using Grupp2.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<RestaurantMongoDBSettings>(builder.Configuration.GetSection("MongoDB"));
builder.Services.AddSingleton<RestaurantMongoDBService>();

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
