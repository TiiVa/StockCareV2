namespace StockCareV2.Application.Interfaces.ServiceInterfaces
{
    public interface IService<TEntity, TId> where TEntity : class
    {

        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(Guid id);
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity, Guid id);
        Task DeleteAsync(Guid id);
    }
}