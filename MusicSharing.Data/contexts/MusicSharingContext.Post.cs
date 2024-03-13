using Microsoft.EntityFrameworkCore;
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
    /// Gets a list of all post titles.
    /// </summary>
    /// <returns>The list of post titles.</returns>
    public async Task<IEnumerable<string>> GetPostTitles()
    {
        return await Posts
                .Select(p => p.Title)
                .ToListAsync();
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
    public async Task RemovePost(int postId)
    {
        var postToRemove = await Posts.FindAsync(postId);
        if(postToRemove != null)
        {
            postToRemove.SetInactive();
            await SaveChangesAsync();
        }
    }
}
