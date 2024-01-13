using Microsoft.EntityFrameworkCore;
using MusicSharing.Buisness.Services.Interfaces;
using MusicSharing.Contracts.Outputs;
using MusicSharing.Data.Contexts.Interfaces;

namespace MusicSharing.Buisness.Services;

/// <summary>
/// The user service.
/// </summary>
public class UserService : IUserService
{
    private readonly IMusicSharingContext context;

    /// <summary>
    /// The instance of the user service.
    /// </summary>
    /// <param name="context">The music sharing context.</param>
    public UserService(IMusicSharingContext context)
    {
        this.context = context;
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

        //TODO: temporary manual map until auto mapper is up and working.
        return new UserDto
        {
            Id = user.Id,
            Name = user.Name,
            SpotifyAccount = user.SpotifyAccount
        };
    }
}