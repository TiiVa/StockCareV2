using StockCareV2.Application.DTOs;
using StockCareV2.Application.Interfaces.RepositoryInterfaces;
using StockCareV2.Infrastructure.Data;

namespace StockCareV2.Infrastructure.Repositories
{
    public class UserRepository(AppDbContext context) : IUserRepository
    {
        public Task<bool> AddAsync(UserDto entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<UserDto> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(UserDto entity, Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
