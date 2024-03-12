using Microsoft.EntityFrameworkCore;
using MusicSharing.Data.Contexts.Interfaces;
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
}
