using Microsoft.EntityFrameworkCore;
using MusicSharing.Data.Contexts;
using MusicSharing.Data.Contexts.Interfaces;
using System.Net;
using System.Text;
using MusicSharing.Business.Extensions;
using MusicSharing.Business.Services;
using MusicSharing.Business.Services.Interfaces;
using MusicSharing.Business.Settings;


var builder = WebApplication.CreateBuilder(args);

// Add configurations.
builder.Configuration.AddEnvironmentVariables().AddJsonFile("appsettings.json");

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddAutoMapper(typeof(MappingProfile));

// Spotify Api Setup
//var obj = builder.Configuration.Ge("SpotifyApi");

IConfiguration config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .Build();

IConfigurationSection section = config.GetSection("SpotifyAPI");

string client_id = section["ClientId"];
string client_secret = section["ClientSecret"];

builder.Services.Configure<SpotifyApiSettings>(section);

builder.Services.AddHttpClient<ISpotifyAccountService, SpotifyAccountService>(c => 
{
    c.BaseAddress = new Uri("https://accounts.spotify.com/api/");
});

builder.Services.AddHttpClient<ISpotifyService, SpotifyService>(c =>
{
    c.BaseAddress = new Uri("https://api.spotify.com/v1/");
    c.DefaultRequestHeaders.Add("Accept", "application/.json");
});

// Initializae Database.
var dbConnection = builder.Configuration.GetConnectionString("MusicSharingDatabase");
builder.Services.AddDbContext<MusicSharingContext>(options => options.UseSqlServer(dbConnection))
    .AddScoped<IMusicSharingContext, MusicSharingContext>();

builder.Services.AddRouting(options => options.LowercaseUrls = true);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
