using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicSharing.Data.entities
{
    /// <summary>
    /// The post object.
    /// </summary>
    [Table("post", Schema = "musicsharing")]
    public class Post
    {
        /// <summary>
        /// The date the post was created on.
        /// </summary>
        public DateTime CreatedOn { get; private set; }

        /// <summary>
        /// The post identifier.
        /// </summary>
        [Key]
        public int Id { get; private set; }

        /// <summary>
        /// A boolean that indicates whether the post is active or not.
        /// </summary>
        public bool IsActive { get; private set; }

        /// <summary>
        /// The post type identifier
        /// </summary>
        public int PostTypeId {  get; private set; }    // Not sure if we will need this, depends on things the can be posted

        /// <summary>
        /// The user identifer of the post creator
        /// </summary>
        public int UserId { get; private set; }

        // Other Post specific information here

        private Post() { }

    }
}
