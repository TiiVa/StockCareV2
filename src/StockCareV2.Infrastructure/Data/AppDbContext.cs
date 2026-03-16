using Microsoft.EntityFrameworkCore;
using StockCareV2.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockCareV2.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
    }
}
