using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicSharing.Contracts.Outputs
{
    /// <summary>
    /// The comment data transfer object.
    /// </summary>
    public class CommentDto
    {
        /// <summary>
        /// The comment string.
        /// </summary>
        public string Comment { get; set; } = default!;

        /// <summary>
        /// The comment's identifier.
        /// </summary>
        public int CommentId { get; set; }

        /// <summary>
        /// The date of the post creation.
        /// </summary>v
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// The user's identifier.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// The name of the user.
        /// </summary>
        public string UserName { get; set; } = default!;
    }
}
