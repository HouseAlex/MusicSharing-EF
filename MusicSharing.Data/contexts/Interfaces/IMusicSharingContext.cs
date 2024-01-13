using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicSharing.Data.Contexts.Interfaces;

/// <summary>
/// A partial interface for the music sharing database context.
/// </summary>
public partial interface IMusicSharingContext
{
    /// <summary>
    /// Save the changes applied to the database.
    /// </summary>
    Task SaveChangesAsync();
}
