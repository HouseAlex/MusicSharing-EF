using Microsoft.EntityFrameworkCore;
using MusicSharing.Data.Contexts.Interfaces;
using MusicSharing.Data.entities;
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
        try
        {
            await Users.AddAsync(user);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
        

        await SaveChangesAsync();
    }

    /// <summary>
    /// Adds the follow to the follow table.
    /// </summary>
    /// <param name="follow">The follow data.</param>
    /// <returns>An empty task.</returns>
    public async Task AddFollow(Follow follow)
    {
        await Follows.AddAsync(follow);

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
    public async Task<User?> GetUserFromSpotifyId(string spotifyId, bool withTracking)
    {
        return withTracking 
            ? await Users.AsNoTracking().FirstOrDefaultAsync(x => x.SpotifyId == spotifyId) 
            : await Users.FirstOrDefaultAsync(x => x.SpotifyId == spotifyId);
    }
}
