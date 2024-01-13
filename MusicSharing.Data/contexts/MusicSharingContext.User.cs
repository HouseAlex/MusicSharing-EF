using Microsoft.EntityFrameworkCore;
using MusicSharing.Data.Contexts.Interfaces;
using MusicSharing.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicSharing.Data.Contexts;

/// <summary>
/// The music sharing database context pertaining to user data.
/// </summary>
public partial class MusicSharingContext : IMusicSharingContext
{
    public async Task<User?> GetUser(int id)
    {
        return await Users.FirstOrDefaultAsync(x => x.Id == id);
    }
}
