using CarWebApi.Database;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//Database context Dependency Injection  
var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
var dbName = Environment.GetEnvironmentVariable("DB_NAME");
var dbPass = Environment.GetEnvironmentVariable("POSTGRES_PASSWORD");
var conStr = $"Host={dbHost};Port=5432;Database={dbName};Username=postgres;Password={dbPass}";
builder.Services.AddDbContext<CarDbContext>(o => o.UseNpgsql(conStr));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
