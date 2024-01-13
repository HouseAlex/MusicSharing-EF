using Microsoft.EntityFrameworkCore;
using MusicSharing.Buisness.Services.Interfaces;
using MusicSharing.Buisness.Services;
using MusicSharing.Data.Contexts;
using MusicSharing.Data.Contexts.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add configurations.
builder.Configuration.AddEnvironmentVariables().AddJsonFile("appsettings.json");

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUserService, UserService>();

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
