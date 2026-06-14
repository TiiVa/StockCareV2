using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using StockCareV2.Application.DTOs;
using StockCareV2.Application.DTOs.Converters;
using StockCareV2.Application.Interfaces.RepositoryInterfaces;
using StockCareV2.Domain.Entities;
using StockCareV2.Infrastructure.Data;

namespace StockCareV2.Infrastructure.Repositories
{
    public class ProductRepository(AppDbContext context) : IProductRepository
    {

        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            return await context.Products
                .Select(p => p.ConvertToDto())
                .ToListAsync();
        }

        public async Task<ProductDto> GetByIdAsync(Guid id)
        {
            var product = await context.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (product is null) return new ProductDto();

            return product.ConvertToDto();
        }
        public async Task<bool> AddAsync(ProductDto entity)
        {
            entity.LastUpdated = DateTime.UtcNow;
            var newProduct = await context.AddAsync(entity);

            if (newProduct is null) return false;

            await context.SaveChangesAsync(); // TODO: Move to UOW 

            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var productToSoftDelete = await context.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (productToSoftDelete is null) return false;

            var entityEntry = context.Products.Update(productToSoftDelete);

            entityEntry.Property(p => p.IsActive).CurrentValue = false;

            await context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateAsync(ProductDto entity, Guid id)
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
            productToUpdate.Quantity = entity.Quantity;


            await context.SaveChangesAsync(); // TODO: Move to UOW

            return true;

        }
    }
}
