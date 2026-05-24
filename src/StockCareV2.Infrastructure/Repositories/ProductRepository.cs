using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Text;
using Microsoft.EntityFrameworkCore;
using StockCareV2.Application.DTOs;
using StockCareV2.Application.Interfaces.RepositoryInterfaces;
using StockCareV2.Domain.Entities;
using StockCareV2.Infrastructure.Data;

namespace StockCareV2.Infrastructure.Repositories
{
    public class ProductRepository(AppDbContext context) : IProductRepository
    {

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await context.Products.ToListAsync();
        }

        public async Task<Product> GetById(Guid id)
        {
            var product = await context.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (product is null) return new Product();

            return product;
        }
        public async Task<bool> AddAsync(Product entity)
        {
            entity.LastUpdated = DateTime.UtcNow;
            var newProduct = await context.AddAsync(entity);

            if (newProduct is null) return false;

            await context.SaveChangesAsync(); // TODO: Move to UOW 

            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var productToDelete = await context.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (productToDelete is null) return false;

            context.Products.Remove(productToDelete);

            return true;
        }

        public async Task<bool> UpdateAsync(Product entity, Guid id)
        {
            var productToUpdate = await context.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (productToUpdate is null) return false;

            productToUpdate.Unit = entity.Unit;
            productToUpdate.Price = entity.Price;
            productToUpdate.LastUpdated = DateTime.UtcNow;
            productToUpdate.Name = entity.Name;
            productToUpdate.IsActive = entity.IsActive;
            productToUpdate.MinStockLevel = entity.MinStockLevel;
            productToUpdate.PackageSize = entity.PackageSize;

            await context.SaveChangesAsync(); // TODO: Move to UOW

            return true;

        }
    }
}
