using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicSharing.Data.entities
{

    [Table("postcomment", Schema = "musicsharing")]
    public class PostComment
    {
        /// <summary>
        /// The comment.
        /// </summary>
        public string Comment { get; private set; } = default!;

        /// <summary>
        /// The date the post comment was created on.
        /// </summary>
        public DateTime CreatedOn { get; private set; }

        /// <summary>
        /// The post comment identifier.
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// A boolean indicating whether the post comment is active.
        /// </summary>
        public bool IsActive { get; private set; }

        /// <summary>
        /// The post identifier.
        /// </summary>
        public int PostId { get; private set; }

        /// <summary>
        /// The user identifier of the commenter.
        /// </summary>
        public int UserId { get; private set; }
    }
}
