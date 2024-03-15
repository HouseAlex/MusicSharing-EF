using MusicSharing.Business.Services.Interfaces;

namespace MusicSharing.Business.Services;

/// <summary>
/// The Spotify service.
/// </summary>
public class SpotifyService : ISpotifyService
{
    private readonly HttpClient _httpClient;
    private readonly ISpotifyAccountService spotifyAccountService;

    /// <summary>
    /// Retrieves and stores the http client and creates a spotify account service object.
    /// </summary>
    /// <param name="httpClient">The http client.</param>
    /// <param name="spotifyAccountService">The http spotify account service.</param>
    public SpotifyService(HttpClient httpClient, ISpotifyAccountService spotifyAccountService)
    {
        _httpClient = httpClient;
        this.spotifyAccountService = spotifyAccountService;
    }

    /// <summary>
    /// Allows us to test the token autorization of the spotify service.
    /// </summary>
    public async Task Test()
    {
        var token = await spotifyAccountService.GetToken() ?? throw new Exception();
        _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

        var response = await _httpClient.GetAsync("search?type=artist&q=Drake");
    }
}