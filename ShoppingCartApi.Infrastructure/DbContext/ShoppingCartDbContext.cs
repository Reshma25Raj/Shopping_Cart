using Microsoft.EntityFrameworkCore;
using ShoppingCartApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartApi.Infrastructure.DbContext
{
    public class ShoppingCartDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
     public ShoppingCartDbContext(DbContextOptions<ShoppingCartDbContext> options)
    : base(options) { }

        public DbSet<CartItem> CartItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed some initial data (optional)
            modelBuilder.Entity<CartItem>().HasData(
                new CartItem { Id = 1, Name = "Item A", Price = 10.99m, Quantity = 1 },
                new CartItem { Id = 2, Name = "Item B", Price = 20.49m, Quantity = 2 }
            );
        }
    }
}
