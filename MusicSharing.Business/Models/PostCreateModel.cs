using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicSharing.Business.Models
{
    public class PostCreateModel
    {
        public string SpotifyId { get; set; }
        public string UserId { get; set; }
        public string Title { get; set; }
    }
}
