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
        public IEnumerable<CommentDto>? Comments { get; set; }

        public DateTime CreatedOn { get; set; }

        public string ImageUrl { get; set; } = default!;

        public string SpotifyId { get; set; } = default!;

        public string SpotifyUrl { get; set; } = default!;

        public string Title { get; set; } = default!;

        public int userId { get; set; }

        public string userName { get; set; } = default!;
    }
}
