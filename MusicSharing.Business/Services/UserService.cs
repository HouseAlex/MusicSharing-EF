using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MusicSharing.Business.Services.Interfaces;
using MusicSharing.Contracts.Outputs;
using MusicSharing.Data.Contexts.Interfaces;

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
    /// Test method.
    /// </summary>
    public async Task Test()
    {
        await spotifyService.Test();
    }
}