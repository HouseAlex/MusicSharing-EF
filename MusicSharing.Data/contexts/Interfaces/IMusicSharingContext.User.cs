using MusicSharing.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicSharing.Data.Contexts.Interfaces;

/// <summary>
/// A partial interface for the music sharing database context pertaining to users.
/// </summary>
public partial interface IMusicSharingContext
{
    Task<User?> GetUser(int id);
}
