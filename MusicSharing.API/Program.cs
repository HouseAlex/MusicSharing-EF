using Microsoft.EntityFrameworkCore;
using MusicSharing.Data.Contexts;
using MusicSharing.Data.Contexts.Interfaces;
using System.Net;
using System.Text;
using MusicSharing.Business.Extensions;
using MusicSharing.Business.Services;
using MusicSharing.Business.Services.Interfaces;

//string GetAccessToken()
//{
//    // Create a new SpotifyToken object to store the access token
//    // SpotifyToken token = new SpotifyToken();
//    var SpotifyToken = "your_spotify_token";

//    // Define the Spotify API endpoint for token retrieval
//    string tokenUrl = "https://accounts.spotify.com/api/token";

//    // Replace 'your_client_id' and 'your_client_secret' with your actual Spotify API credentials
//    var clientId = "your_client_id";
//    var clientSecret = "your_client_secret";

//    // Encode the client ID and client secret for the Authorization header
//    var encodedClientCredentials = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{clientId}:{clientSecret}"));

//    // Create a HttpWebRequest to make a POST request to the Spotify API for token retrieval
//    HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(tokenUrl);
//    webRequest.Method = "POST";
//    webRequest.ContentType = "application/x-www-form-urlencoded";
//    webRequest.Accept = "application/json";

//    // Add Authorization header with the encoded client credentials
//    webRequest.Headers.Add($"Authorization: Basic {encodedClientCredentials}");

//    // Specify the grant type as 'client_credentials'
//    var requestBody = "grant_type=client_credentials";
//    byte[] requestBodyBytes = Encoding.ASCII.GetBytes(requestBody);
//    webRequest.ContentLength = requestBodyBytes.Length;

//    // Write the request body to the request stream
//    using (Stream requestStream = webRequest.GetRequestStream())
//    {
//        requestStream.Write(requestBodyBytes, 0, requestBodyBytes.Length);
//    }

//    // Get the response from the Spotify API
//    using (HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse())
//    {
//        // Read the response stream
//        using (Stream responseStream = response.GetResponseStream())
//        {
//            using (StreamReader reader = new StreamReader(responseStream, Encoding.UTF8))
//            {
//                // Get the JSON response containing the access token
//                string jsonResponse = reader.ReadToEnd();

//                // Parse the JSON and set the access token in the 'token' object
//                // token.access_token = ParseAccessTokenFromJson(jsonResponse);
//            }
//        }
//    }
//    object token = null;
//    // Return the access token
//    return token.access_token;

//}

//// Helper method to parse the access token from the JSON response
//string ParseAccessTokenFromJson(string jsonResponse)
//{
//    // Later we can implement logic if we wanted to get a parsed token from the
//    // Spotify api.
//    return "your_parsed_access_token";
//}

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

builder.Services.AddHttpClient<ISpotifyAccountService, SpotifyAccountService>(c => 
{
    c.BaseAddress = new Uri("https://accounts.spotify.com/api");
});

//builder.Services.AddHttpClient<ISpotifyService, SpotifyService>(c =>
//{
//    c.BaseAddress = new Uri("https://api.spotify.com/v1");
//    c.DefaultRequestHeaders.Add("Accept", "application/.json");
//});

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
