﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicSharing.Data.Entities;

public class User
{
    /// <summary>
    /// The user identifier.
    /// </summary>
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
    /// The spotify user identifier.
    /// </summary>
    public string SpotifyId { get; private set; } = default!;

    private User() { }

    /// <summary>
    /// Creates a new user entity.
    /// </summary>
    /// <param name="name">The user's name.</param>
    /// <returns>The created user.</returns>
    public static User Create(
        string name,
        string spotifyId)
    {
        // can add validation here.

        return new User
        {
            IsActive = true,
            Name = name,
            SpotifyId = spotifyId
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
