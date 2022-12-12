using Grupp2.Models;
using Grupp2.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<ThoughtsDatabaseSettings>(
builder.Configuration.GetSection("ThoughtsMongoDB")); 
builder.Services.AddSingleton<ThoughtService>();

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
