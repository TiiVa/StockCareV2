using System;
using System.Collections.Generic;
using System.Text;

namespace StockCareV2.Application.Interfaces.RepositoryInterfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(Guid id);
        Task<bool> AddAsync(TEntity entity);
        Task<bool> UpdateAsync(TEntity entity, Guid id);
        Task<bool> DeleteAsync(Guid id);
    }
}
