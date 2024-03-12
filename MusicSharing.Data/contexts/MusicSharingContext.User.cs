using Microsoft.EntityFrameworkCore;
using MusicSharing.Data.Contexts.Interfaces;
using MusicSharing.Data.Entities;

namespace MusicSharing.Data.Contexts;

/// <summary>
/// The music sharing database context pertaining to user data.
/// </summary>
public partial class MusicSharingContext : IMusicSharingContext
{
    /// <summary>
    /// Adds the new user to the user table.
    /// </summary>
    /// <param name="user">The user data</param>
    /// <returns>An empty task.</returns>
    public async Task AddUser(User user)
    {
        await Users.AddAsync(user);

        await SaveChangesAsync();
    }

    /// <summary>
    /// Gets the user from the user identifier.
    /// </summary>
    /// <param name="id">The user identifier.</param>
    /// <returns>The user.</returns>
    public async Task<User?> GetUser(int id)
    {
        var test = await Users.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        return test;
    }

    /// <summary>
    /// Gets the user from the spotify identifier.
    /// </summary>
    /// <param name="spotifyId">The spotify user identifier.</param>
    /// <returns>The user.</returns>
    public async Task<User?> GetUserFromSpotifyId(string spotifyId)
    {
        return await Users.FirstOrDefaultAsync(x => x.SpotifyId == spotifyId);
    }
}
