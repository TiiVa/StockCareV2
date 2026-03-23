using Microsoft.EntityFrameworkCore;
using StockCareV2.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockCareV2.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderProduct>()
            .HasKey(op => new { op.StockId, op.ProductId });

            base.OnModelCreating(modelBuilder);
        }


    }
}
