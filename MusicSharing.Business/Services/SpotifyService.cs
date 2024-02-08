using MusicSharing.Business.Services.Interfaces;

namespace MusicSharing.Business.Services;

public class SpotifyService
{
    private readonly HttpClient _httpClient;
    private readonly ISpotifyAccountService spotifyAccountService;

    public SpotifyService(HttpClient httpClient, ISpotifyAccountService spotifyAccountService)
    {
        _httpClient = httpClient;
        this.spotifyAccountService = spotifyAccountService;
    }
}