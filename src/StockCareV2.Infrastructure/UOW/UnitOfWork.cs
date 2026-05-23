using Microsoft.EntityFrameworkCore;
using StockCareV2.Application.Interfaces;
using StockCareV2.Application.Interfaces.RepositoryInterfaces;
using StockCareV2.Domain.Entities;
using StockCareV2.Infrastructure.Data;
using StockCareV2.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockCareV2.Infrastructure.UOW
{
    internal class UnitOfWork : IUnitOfWork
    {

        private readonly AppDbContext _dbContext;
        public IProductRepository Products { get; private set; }

        public IProductRepository ProductRepository
        {
            get
            {
                if (Products == null)
                {
                    Products = new ProductRepository(_dbContext);
                }

                return Products;
            }
        }

        public async Task CommitAsync()
        {
            if(_dbContext is not null)
            {
                await _dbContext.SaveChangesAsync();
            }
            
        }

        public void Dispose()
        {
            if(_dbContext is not null)
            {
                _dbContext.Dispose();
            }
        }
    }
}
