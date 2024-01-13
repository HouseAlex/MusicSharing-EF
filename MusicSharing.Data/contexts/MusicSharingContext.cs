using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicSharing.Data.Contexts;

/// <summary>
/// The music sharing database context.
/// </summary>
public class MusicSharingContext : DbContext
{
    public MusicSharingContext(DbContextOptions<MusicSharingContext> options) : base(options)
    {
    }
}
