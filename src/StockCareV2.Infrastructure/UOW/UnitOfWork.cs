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
            IProductRepository productRepository,
            IOrderRepository orderRepository,
            IUserRepository userrepository,
            IStockRepository stockrepository)
        {
            _dbContext = dbContext;
            ProductRepository = productRepository;
            OrderRepository = orderRepository;
            UserRepository = userrepository;
            StockRepository = stockrepository;
        }

        public IProductRepository ProductRepository { get; }
        public IOrderRepository OrderRepository { get; set; }
        public IUserRepository UserRepository { get; set; }
        public IStockRepository StockRepository { get; set; }

        public Task CommitAsync()
            => _dbContext.SaveChangesAsync();

        public void Dispose()
            => _dbContext.Dispose();
    }
}
