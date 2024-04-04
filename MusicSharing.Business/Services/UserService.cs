using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MusicSharing.Business.Services.Interfaces;
using MusicSharing.Contracts.Inputs;
using MusicSharing.Contracts.Outputs;
using MusicSharing.Data.Contexts.Interfaces;
using MusicSharing.Data.entities;
using MusicSharing.Data.Entities;

namespace MusicSharing.Business.Services;

/// <summary>
/// The user service.
/// </summary>
public class UserService : IUserService
{
    private readonly IMusicSharingContext context;
    private readonly IMapper mapper;
    private readonly ISpotifyService spotifyService;

    /// <summary>
    /// The instance of the user service.
    /// </summary>
    /// <param name="context">The music sharing context.</param>
    public UserService(IMusicSharingContext context,
        IMapper mapper,
        ISpotifyService spotifyService)
    {
        this.context = context;
        this.mapper = mapper;
        this.spotifyService = spotifyService;
    }

    /// <summary>
    /// Registers a new user for our system.
    /// </summary>
    /// <param name="payload">A payload of the new user user's information.</param>
    /// <returns>An empty task.</returns>
    public async Task AddUser(NewUserPayload payload)
    {
        var newUser = User.Create(payload.DisplayName, payload.SpotifyId);
        await context.AddUser(newUser);
    }

    /// <summary>
    /// Checks to see if the spotify account exits in our system.
    /// </summary>
    /// <param name="spotifyId">The spotify user identifier.</param>
    /// <returns>A boolean indicating whethere the user exists.</returns>
    public async Task<bool> CheckUserExists(string spotifyId)
    {
        var user = await context.GetUserFromSpotifyId(spotifyId, false);
        
        return user != null;
    }

    public async Task FollowUser(FollowPayload payload)
    {
        var user = await context.GetUserFromSpotifyId(payload.FollowUserName, false) ?? throw new Exception("Entered user name does not exist on the app.");

        var followObj = Follow.Create(user.Id, payload.UserId);
        await context.AddFollow(followObj);
    }

    /// <summary>
    /// Gets the user for the identifier.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns>A bool for now.</returns>
    public async Task<UserDto> GetUser(int id)
    {
        var user = await context.GetUser(id);
        if (user == null)
        {
            throw new Exception();
        }

        return mapper.Map<UserDto>(user);
    }

    /// <summary>
    /// Gets the user from the spotify identifier.
    /// </summary>
    /// <param name="userId">The user identifier.</param>
    /// <returns>The user.</returns>
    public async Task<UserDto> GetUserFromSpotifyId(string spotifyId)
    {
        var user = await context.GetUserFromSpotifyId(spotifyId, false);

        if (user == null)
        {
            throw new Exception();
        }

        return mapper.Map<UserDto>(user);
    }

    /// <summary>
    /// Test method.
    /// </summary>
    public async Task Test()
    {
        await spotifyService.Test();
    }
}