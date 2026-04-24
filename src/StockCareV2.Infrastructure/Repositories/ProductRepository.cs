using System;
using System.Collections.Generic;
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

        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ProductDto> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> AddAsync(ProductDto entity)
        {
            var entityModel = await context.Products.FindAsync(entity.Id);

            if(entityModel is null)
            {
                return false;

            }

            context.Products.Add(entityModel);

            return true;

        }

        public Task<bool> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

       

        public Task<bool> UpdateAsync(ProductDto entity, Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
