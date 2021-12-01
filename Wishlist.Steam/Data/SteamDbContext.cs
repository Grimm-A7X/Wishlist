using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WishlistSteam.Models;

namespace WishlistSteam.Data
{
    public class SteamDbContext : DbContext
    {
        public SteamDbContext(DbContextOptions options)
        : base(options)
        {

        }

        public DbSet<Wishlist> Wishlists { get; set; }

        
    }
}
