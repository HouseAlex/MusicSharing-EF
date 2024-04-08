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
    public async Task<Post?> AddPost(Post post)
    {
        await Posts.AddAsync(post);
        await SaveChangesAsync();

        var obj = await Posts
            .Include(x => x.User)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == post.Id);
        return obj;
    }

    /// <summary>
    /// Adds a post like to the database.
    /// </summary>
    /// <param name="postLike">The post like object.</param>
    public async Task AddPostLike(PostLike postLike)
    {
        await PostLikes.AddAsync(postLike);
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
    /// Gets the post like object.
    /// </summary>
    /// <param name="postId">The post identifier.</param>
    /// <param name="userId">The user identifier.</param>
    /// <returns>The post like object.</returns>
    public async Task<PostLike?> GetPostLike(int postId, int userId)
    {
        return await PostLikes.FirstOrDefaultAsync(x => x.PostId == postId && x.UserId == userId && x.IsActive);
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

        // add user to list of posts wanted.
        following.Add(userId);
        
        #nullable disable
        var posts = await Posts
            .Where(x => x.IsActive)
            .Where(x => following.Contains(x.UserId))
            .Include(x => x.Comments.Where(c => c.IsActive))
                .ThenInclude(t => t.User)
            .Include(x => x.User)
            .Include(x => x.Likes.Where(l => l.IsActive))
            .Select(x => new PostDto
            {
                Comments = x.Comments != null ? x.Comments.Where(c => c.IsActive).Select(c => new CommentDto
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
                Id = x.Id,
                ImageUrl = x.ImageUrl,
                LikeTotal = x.Likes.Where(c => c.IsActive) != null ? x.Likes.Where(c => c.IsActive).Count() : 0,
                IsLikedByUser = x.Likes != null ?  x.Likes.Any(x => x.UserId == userId && x.IsActive) : false,
                SpotifyId = x.SpotifyId,
                SpotifyUrl = x.SpotifyUrl,
                TrackName = x.TrackName,
                UserId = x.UserId,
                UserName = x.User.Name
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

