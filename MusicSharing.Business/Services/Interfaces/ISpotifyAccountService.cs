using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicSharing.Business.Services.Interfaces
{
    /// <summary>
    /// An interface for the spotify account service.
    /// </summary>
    public interface ISpotifyAccountService
    {
        /// <summary>
        /// Gets a token.
        /// </summary>
        Task<string> GetToken();
    }
}
