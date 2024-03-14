using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicSharing.Contracts.Outputs
{
    /// <summary>
    /// This class represents a data transfer object (DTO) for a post.
    /// </summary>
    public class PostDto
    {
        public string SpotifyId { get; set; } = default!;

        public string userName { get; set; } = default!;
    }
}
