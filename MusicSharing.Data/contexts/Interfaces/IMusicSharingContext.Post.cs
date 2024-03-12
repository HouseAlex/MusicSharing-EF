using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicSharing.Data.Contexts.Interfaces
{
    public partial interface IMusicSharingContext
    {
        Task<IEnumerable<string>> GetPostTitles();
    }
}
