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

        public int CommentId { get; set; } = default;

        public DateTime CreatedOn { get; set; }

        public string UserId { get; set; } = default!;

        public string UserName { get; set; } = default!;
    }
}
