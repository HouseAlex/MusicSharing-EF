using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicSharing.Contracts.Inputs
{
    public class PostCreatePayload
    {
        public string SpotifyId { get; } = default!;
        public int UserId { get; } = default!;
        public string Title { get; } = default!;
    }
}
