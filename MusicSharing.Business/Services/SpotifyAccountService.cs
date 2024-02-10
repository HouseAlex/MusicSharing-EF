using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MusicSharing.Business.Models;
using MusicSharing.Business.Services.Interfaces;
using MusicSharing.Business.Settings;

namespace MusicSharing.Business.Services
{
    public class SpotifyAccountService : ISpotifyAccountService
    {
        private readonly HttpClient _httpClient;
        private readonly SpotifyApiSettings settings;

        public SpotifyAccountService(HttpClient httpClient, IOptions<SpotifyApiSettings> spotifyApiSettings)
        {
            _httpClient = httpClient;
            settings = spotifyApiSettings.Value;
        }

        /// <summary>
        /// Gets the token for the spotify api.
        /// </summary>
        /// <returns>The authorization token.</returns>
        /// <exception cref="Exception"></exception>
        public async Task<string> GetToken()
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "token");

            request.Headers.Authorization = new AuthenticationHeaderValue(
                "Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes($"{settings.ClientId}: {settings.ClientSecret}")));

            request.Content = new FormUrlEncodedContent(new Dictionary<string, string>
            {
                {"grant_type", "client_credentials" }
            });

            var response = await _httpClient.SendAsync(request);

            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();
            var authResult = await JsonSerializer.DeserializeAsync<AuthResult>(responseStream);

            if (authResult == null)
            {
                // Add something here later.
                throw new Exception();
            }

            return authResult.access_token;
        }
    }
}
