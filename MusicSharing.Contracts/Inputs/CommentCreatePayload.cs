using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicSharing.Contracts.Inputs
{
    public class CommentCreatePayload
    {
        public string Comment { get; } = default!;

        public int PostId { get; } = default!;

        public int UserId { get; } = default!;
    }
}
