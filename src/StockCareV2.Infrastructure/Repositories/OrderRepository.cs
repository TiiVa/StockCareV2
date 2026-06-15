using StockCareV2.Application.DTOs;
using StockCareV2.Application.Interfaces.RepositoryInterfaces;
using StockCareV2.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockCareV2.Infrastructure.Repositories
{
    internal class OrderRepository(AppDbContext context) : IOrderRepository
    {
        public Task<bool> AddAsync(OrderDto entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<OrderDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<OrderDto> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(OrderDto entity, Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
