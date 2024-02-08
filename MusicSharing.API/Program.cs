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
builder.Services.Configure<SpotifyApiSettings>(builder.Configuration.GetSection("SpotifyApi"));

builder.Services.AddHttpClient<ISpotifyAccountService, SpotifyAccountService>(c => 
{
    c.BaseAddress = new Uri("https://accounts.spotify.com/api");
});

builder.Services.AddHttpClient<ISpotifyService, SpotifyService>(c =>
{
    c.BaseAddress = new Uri("https://api.spotify.com/v1");
    c.DefaultRequestHeaders.Add("Accept", "application/.json");
});

// Initializae Database.
var dbConnection = builder.Configuration.GetConnectionString("MusicSharingDatabase");
builder.Services.AddDbContext<MusicSharingContext>(options => options.UseSqlServer(dbConnection))
    .AddScoped<IMusicSharingContext, MusicSharingContext>();

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
