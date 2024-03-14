using Microsoft.EntityFrameworkCore;
using MusicSharing.Contracts.Inputs;
using MusicSharing.Contracts.Outputs;

namespace MusicSharing.Business.Services.Interfaces;

/// <summary>
/// An interface for the user service.
/// </summary>
public interface IUserService
{
    Task<bool> CheckUserExists(string spotifyId);

    //Task<MusicSharing.API.Controllers.InstagramPostDto> getPostInformation(string postId);
    Task<UserDto> GetUser(int id);

    Task<UserDto> GetUserFromSpotifyId(string spotifyId);

    Task AddUser(NewUserPayload payload);

    Task Test();
}