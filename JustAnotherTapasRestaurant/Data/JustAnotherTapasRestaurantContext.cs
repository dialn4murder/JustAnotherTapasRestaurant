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

        // Will update the context to include the table
        public DbSet<MenuItem> MenuItems { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<MenuItem>().ToTable("MenuItem");
        }

    }
}
