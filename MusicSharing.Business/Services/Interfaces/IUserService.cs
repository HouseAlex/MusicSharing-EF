using Microsoft.EntityFrameworkCore;
using MusicSharing.Contracts.Inputs;
using MusicSharing.Contracts.Outputs;

namespace MusicSharing.Business.Services.Interfaces;

/// <summary>
/// An interface for the user service.
/// </summary>
public interface IUserService
{
    /// <summary>
    /// Checks to see if the spotify account exits in our system.
    /// </summary>
    /// <param name="spotifyId">The spotify user identifier.</param>
    /// <returns>A boolean indicating whethere the user exists.</returns>
    Task<bool> CheckUserExists(string spotifyId);

    //Task<MusicSharing.API.Controllers.InstagramPostDto> getPostInformation(string postId);

    /// <summary>
    /// Retrieves a user based on their spotify id
    /// </summary>
    /// <param name="id">The id of the spotify user.</param>
    /// <returns>A user based on their id</returns>
    Task<UserDto> GetUser(int id);

    /// <summary>
    /// Gets a user based on their spotify id.
    /// </summary>
    /// <param name="spotifyId">The spotify user identifier.</param>
    /// <returns>The user determined by their spotify id.</returns>
    Task<UserDto> GetUserFromSpotifyId(string spotifyId);

    /// <summary>
    /// Adds a new user.
    /// </summary>
    /// <param name="payload">The model of the new user.</param>
    /// <returns>A new user.</returns>
    Task AddUser(NewUserPayload payload);

    /// <summary>
    /// Testing function.
    /// </summary>
    Task Test();
}