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
/// The music sharing database context.
/// </summary>
public partial class MusicSharingContext : DbContext, IMusicSharingContext
{
    public DbSet<User> Users { get; set; } = default!;

    /// <summary>
    /// The instance of the music sharing database context.
    /// </summary>
    /// <param name="options">The database context options.</param>
    public MusicSharingContext(DbContextOptions<MusicSharingContext> options) : base(options)
    {
    }

    /// <summary>
    /// Asychronously save the database changes.
    /// </summary>
    /// <returns>An empty task.</returns>
    public async Task SaveChangesAsync()
    {
        await base.SaveChangesAsync();
    }
}
