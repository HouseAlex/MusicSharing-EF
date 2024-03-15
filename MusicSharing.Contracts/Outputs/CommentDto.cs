using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicSharing.Contracts.Outputs
{
    public class CommentDto
    {
        public string Comment { get; set; } = default!;

        public int CommentId { get; set; }

        public DateTime CreatedOn { get; set; }

        public int UserId { get; set; }

        public string UserName { get; set; } = default!;
    }
}
