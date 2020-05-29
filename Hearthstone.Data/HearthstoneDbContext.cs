using System;
using Hearthstone.Core;
using Microsoft.EntityFrameworkCore;

namespace Hearthstone.Data
{
    public class HearthstoneDbContext : DbContext
    {

        public HearthstoneDbContext(DbContextOptions<HearthstoneDbContext> options) : base(options)
        {

        }

        public DbSet<Card> Cards { get; set; }
    }
}
