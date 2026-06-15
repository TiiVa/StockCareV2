using StockCareV2.Application.DTOs;
using StockCareV2.Application.Interfaces.RepositoryInterfaces;
using StockCareV2.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockCareV2.Infrastructure.Repositories
{
    public class StockRepository(AppDbContext context) : IStockRepository
    {
        public Task<bool> AddAsync(StockDto entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<StockDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<StockDto> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(StockDto entity, Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
