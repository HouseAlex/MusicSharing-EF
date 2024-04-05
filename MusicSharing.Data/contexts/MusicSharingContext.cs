using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicSharing.Data.Contexts.Interfaces;
using MusicSharing.Data.entities;
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
    public DbSet<Follow> Follows { get; set; } = default!;

    public DbSet<Post> Posts { get; set; }

    public DbSet<PostComment> PostComments { get; set; } = default!;

    public DbSet<PostLike> PostLikes { get; set; } = default!;

    public DbSet<User> Users { get; set; }


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

    // Override OnModelCreating
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("musicsharing");

        modelBuilder.Entity<Follow>(entity =>
        {
            entity.ToTable("follow");
            entity.Property(p => p.Id).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.ToTable("post");
            entity.Property(p => p.Id).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<PostComment>(entity =>
        {
            entity.ToTable("postcomment");
            entity.Property(p => p.Id).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<PostLike>(entity =>
        {
            entity.ToTable("postlike");
            entity.Property(p => p.Id).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("user");
            entity.Property(p => p.Id).ValueGeneratedOnAdd();
        });
    }
}
