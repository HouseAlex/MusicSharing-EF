using Microsoft.EntityFrameworkCore;
using MusicSharing.Contracts.Outputs;
using MusicSharing.Data.Contexts.Interfaces;
using MusicSharing.Data.entities;
using MusicSharing.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicSharing.Data.Contexts;

public partial class MusicSharingContext : IMusicSharingContext
{
    /// <summary>
    /// Allows the ability to add more comments.
    /// </summary>
    public async Task AddComment(PostComment comment)
    {
        await PostComments.AddAsync(comment);
        await SaveChangesAsync();
    }

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
    /// <param name="userId">The user identifier.</param>
    /// <returns>A list of the posts for the feed.</returns>
    public async Task<IEnumerable<PostDto>> GetPostFeedForUser(int userId)
    {
        var following = await Follows
            .Where(x => x.UserId == userId && x.IsActive)
            .Select(x => x.FollowId)
            .ToListAsync();
        
        #nullable disable
        var posts = await Posts
            .Where(x => x.IsActive)
            .Where(x => following.Contains(x.UserId))
            .Include(x => x.Comments)
                .ThenInclude(t => t.User)
            .Include(x => x.User)
            .Select(x => new PostDto
            {
                Comments = x.Comments != null ? x.Comments.Select(c => new CommentDto
                {
                    CommentId = c.Id,
                    Comment = c.Comment,
                    CreatedOn = c.CreatedOn,
                    UserId = c.UserId,
                    UserName = c.User!.Name
                }).OrderByDescending(x => x.CreatedOn).ToList() : null,
                ArtistName = x.ArtistName,
                Caption = x.Caption,
                CreatedOn = x.CreatedOn,
                ImageUrl = x.ImageUrl,
                SpotifyId = x.SpotifyId,
                SpotifyUrl = x.SpotifyUrl,
                TrackName = x.TrackName,
                UserId = x.UserId,
                UserName = x.User!.Name
            })
            .OrderByDescending(x => x.CreatedOn)
            .Take(30)   // Hard coded to only retrieve 30 most recent posts for now. Can be changed to dynamic pagination later.
            .ToListAsync();
        #nullable restore

        return posts;
    }

    /// <summary>
    /// Gets a list of all post titles.
    /// </summary>
    /// <returns>The list of post titles.</returns>
    public async Task<IEnumerable<string>> GetPostTitles()
    {
        return await Posts
                .Select(p => p.Caption)
                .ToListAsync();
    }
}

