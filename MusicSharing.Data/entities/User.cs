using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicSharing.Data.Entities;

[Table("user", Schema = "musicsharing")]
public class User
{
    /// <summary>
    /// The user identifier.
    /// </summary>
    [Key]
    public int Id { get; private set; }

    /// <summary>
    /// A value indicating whether the user is active.
    /// </summary>
    public bool IsActive { get; private set; }

    /// <summary>
    /// The name.
    /// </summary>
    public string Name { get; private set; } = default!;

    /// <summary>
    /// The spotify account.
    /// </summary>
    public string SpotifyAccount { get; private set; } = default!;

    private User() { }

    /// <summary>
    /// Creates a new user entity.
    /// </summary>
    /// <param name="name">The user's name.</param>
    /// <param name="spotifyAccount">The spotify account name.</param>
    /// <returns>The created user.</returns>
    public static User Create(
        string name,
        string spotifyAccount)
    {
        // can add validation here.

        return new User
        {
            IsActive = true,
            Name = name,
            SpotifyAccount = spotifyAccount
        };
    }

    /// <summary>
    /// Updates the user entity.
    /// </summary>
    /// <param name="name">The user's name.</param>
    public void Update(
        string name)
    {
        Name = name;
    }

    /// <summary>
    /// Soft deletes the user entity.
    /// </summary>
    public void Delete()
    {
        IsActive = false;
    }
}
