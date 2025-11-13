using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class PartyDbContext : DbContext
    {
        public DbSet<Party> Parties { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Invitation> Invitations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("YourConnectionString");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Invitation>()
                .HasKey(i => i.Id);
        }
    }
}
