using MusicSharing.Business.Services.Interfaces;

namespace MusicSharing.Business.Services;

public class SpotifyService : ISpotifyService
{
    private readonly HttpClient _httpClient;
    private readonly ISpotifyAccountService spotifyAccountService;

    public SpotifyService(HttpClient httpClient, ISpotifyAccountService spotifyAccountService)
    {
        _httpClient = httpClient;
        this.spotifyAccountService = spotifyAccountService;
    }

    public async Task Test()
    {
        var token = await spotifyAccountService.GetToken() ?? throw new Exception();
        _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

        var response = await _httpClient.GetAsync("search?type=artist&q=Drake");
    }
}