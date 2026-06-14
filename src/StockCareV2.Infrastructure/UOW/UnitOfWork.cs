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
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;

        public UnitOfWork(
            AppDbContext dbContext,
            IProductRepository productRepository)
        {
            _dbContext = dbContext;
            ProductRepository = productRepository;
        }

        public IProductRepository ProductRepository { get; }

        public Task CommitAsync()
            => _dbContext.SaveChangesAsync();

        public void Dispose()
            => _dbContext.Dispose();
    }
}
