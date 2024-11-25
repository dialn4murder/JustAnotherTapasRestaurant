using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JustAnotherTapasRestaurant.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace JustAnotherTapasRestaurant.Data
{
    public class JustAnotherTapasRestaurantContext : DbContext
    {
        public JustAnotherTapasRestaurantContext (DbContextOptions<JustAnotherTapasRestaurantContext> options)
            : base(options)
        {
        }

        // public DbSet<JustAnotherTapasRestaurant.Models.MenuItem> MenuItem { get; set; } = default!;
        public DbSet<MenuItem> MenuItems { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<MenuItem>().ToTable("MenuItem");
        }

    }
}
