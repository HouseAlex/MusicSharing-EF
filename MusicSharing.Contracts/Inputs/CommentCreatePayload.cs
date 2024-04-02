using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicSharing.Contracts.Inputs
{
    /// <summary>
    /// A payload containing information needed to create a new comment.
    /// </summary>
    public class CommentCreatePayload
    {
        /// <summary>
        /// The comment string.
        /// </summary>
        public string Comment { get; set; } = default!;

        /// <summary>
        /// The post's identifier.
        /// </summary>
        public int PostId { get; set; } = default!;

        /// <summary>
        /// The user's identifier.
        /// </summary>
        public int UserId { get; set; } = default!;
    }
}
