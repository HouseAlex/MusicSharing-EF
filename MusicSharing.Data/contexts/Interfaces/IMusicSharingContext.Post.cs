using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicSharing.Data.entities;
using MusicSharing.Data.Entities;

namespace MusicSharing.Data.Contexts.Interfaces
{
    public partial interface IMusicSharingContext
    {
        Task<IEnumerable<string>> GetPostTitles();
        Task AddPost(Post post);
        Task<Post?> GetPost(int postId);
        Task CreatePost(Post post);

    }
}
