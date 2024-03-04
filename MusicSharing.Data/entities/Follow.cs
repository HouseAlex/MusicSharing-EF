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
    /// A data object representing a many to many table to track follows
    /// </summary>
    [Table("follow", Schema = "musicsharing")]
    public class Follow
    {
        /// <summary>
        /// The indentifier of who the user is following.
        /// </summary>
        public int FollowId { get; set; }

        /// <summary>
        /// The follows identifier.
        /// </summary>
        [Key]
        public int Id { get; private set; }

        /// <summary>
        /// The user identifier.
        /// </summary>
        public int UserId { get; private set; }

        private Follow() { }
    }
}
