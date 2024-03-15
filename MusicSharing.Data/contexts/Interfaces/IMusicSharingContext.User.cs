using MusicSharing.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicSharing.Data.Contexts.Interfaces;

/// <summary>
/// A partial interface for the music sharing database context pertaining to users.
/// </summary>
public partial interface IMusicSharingContext
{
    /// <summary>
    /// Adds a user to the database.
    /// </summary>
    /// <param name="user">The user that is getting added.</param>
    Task AddUser(User user);

    /// <summary>
    /// Gets user information based on an id.
    /// </summary>
    /// <param name="id">The id of the user.</param>
    Task<User?> GetUser(int id);

    /// <summary>
    /// Gets a user from their spotify id.
    /// </summary>
    /// <param name="spotifyId">The id of the user's spotify.</param>
    /// <param name="withTracking">The option to add a post with or without tracking.</param>
    Task<User?> GetUserFromSpotifyId(string spotifyId, bool withTracking);
}
