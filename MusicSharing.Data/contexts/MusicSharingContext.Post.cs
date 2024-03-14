using Microsoft.EntityFrameworkCore;
using MusicSharing.Contracts.Outputs;
using MusicSharing.Data.Contexts.Interfaces;
using MusicSharing.Data.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicSharing.Data.Contexts;

public partial class MusicSharingContext : IMusicSharingContext
{
    /// <summary>
    /// Allows the ability to add more post titles.
    /// </summary>
    public async Task AddPost(Post post)
    {
        await Posts.AddAsync(post);
        await SaveChangesAsync();
    }

    /// <summary>
    /// Allows the ability to remove post titles.
    /// </summary>
    public async Task<Post?> GetPost(int postId, bool withTracking)
    {
        return withTracking 
            ? await Posts.FirstOrDefaultAsync(x => x.Id == postId) 
            : await Posts.AsNoTracking().FirstOrDefaultAsync(x => x.Id == postId);
    }

    /// <summary>
    /// Gets the post feed for a user.
    /// </summary>
    /// <param name="spotifyId">The user's spotify identifier.</param>
    /// <returns>A list of the posts for the feed.</returns>
    public async Task<IEnumerable<PostDto>> GetPostFeedForUser(string spotifyId)
    {
        // Get the user first.
        var user = await Users
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.SpotifyId == spotifyId) ?? throw new Exception();

        var following = await Follows
            .AsNoTracking()
            .Where(x => x.UserId == user.Id)
            .Select(x => x.FollowId)
            .ToListAsync();

        var posts = await Posts
            .Where(x => following.Contains(x.UserId))
            .Include(x => x.Comments)
            .Include(x => x.User)
            .Select(x => new PostDto
            {

            })
            .ToListAsync();
            
    }

    /// <summary>
    /// Gets a list of all post titles.
    /// </summary>
    /// <returns>The list of post titles.</returns>
    public async Task<IEnumerable<string>> GetPostTitles()
    {
        return await Posts
                .Select(p => p.Title)
                .ToListAsync();
    }
}

