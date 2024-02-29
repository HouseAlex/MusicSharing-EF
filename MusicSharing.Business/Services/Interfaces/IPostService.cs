using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicSharing.Contracts.Outputs;

namespace MusicSharing.Business.Services.Interfaces
{
    public interface IPostService
    {
        Task<PostDto> GetPost(string postId);

        Task<PostDto> GetPostInformation(string postId);
    }
}
