using Microsoft.EntityFrameworkCore;
using MusicSharing.Data.Contexts.Interfaces;
using MusicSharing.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    public async Task<User?> GetUser(int id)
    {
        var test = await Users.FirstOrDefaultAsync(x => x.Id == id);
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
