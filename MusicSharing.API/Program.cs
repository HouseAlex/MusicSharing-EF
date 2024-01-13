using Microsoft.EntityFrameworkCore;
using MusicSharing.Buisness.Services.Interfaces.IUserService;
using MusicSharing.Buisness.Services.UserService;
using MusicSharing.Data.Contexts;

var builder = WebApplication.CreateBuilder(args);

// Add configurations.
builder.Configuration.AddEnvironmentVariables().AddJsonFile("appsettings.json");

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUserService, UserService>();

var dbConnection = builder.Configuration.GetConnectionString("MusicSharingDatabase");
builder.Services.AddDbContext<MusicSharingContext>(options => options.UseSqlServer(dbConnection));

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
