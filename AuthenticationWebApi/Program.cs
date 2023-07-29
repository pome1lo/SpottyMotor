using AuthenticationWebApi.Database;
using AuthenticationWebApi.Services;
using JWTAuthenticationManager;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//Database context Dependency Injection  
var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
var dbName = Environment.GetEnvironmentVariable("DB_NAME");
var dbPass = Environment.GetEnvironmentVariable("DB_SA_PASSWORD");
var conntectionString = $"Data Source={dbHost};Initial Catalog={dbName};User ID=sa;Password={dbPass};TrustServerCertificate=true;";
builder.Services.AddDbContext<UserAccountDbContext>(opt => opt.UseSqlServer(conntectionString));

builder.Services.AddSingleton<JwtTokenHandler>();
builder.Services.AddSingleton<ProviderMailService>();



var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthentication();
app.UseAuthorization();

app.UseRouting();

app.MapControllers();

app.Run();