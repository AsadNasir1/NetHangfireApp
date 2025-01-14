using Microsoft.EntityFrameworkCore;
using NetHangfireDB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetHangfireDB
{
    public class NetHangfireDBContext : DbContext
    {
        public NetHangfireDBContext()
        {
        }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Movie> Movies { get; set; }

        public NetHangfireDBContext(DbContextOptions<NetHangfireDBContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // You don't actually ever need to call this
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>();
            modelBuilder.Entity<Movie>();
        }


    }
}
