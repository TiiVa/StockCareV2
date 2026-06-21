using Microsoft.EntityFrameworkCore;
using StockCareV2.Application.DTOs;
using StockCareV2.Application.DTOs.Converters;
using StockCareV2.Application.Interfaces.RepositoryInterfaces;
using StockCareV2.Domain.Entities;
using StockCareV2.Infrastructure.Data;

namespace StockCareV2.Infrastructure.Repositories
{
    public class UserRepository(AppDbContext context) : IUserRepository
    {
        public async Task<bool> AddAsync(UserDto entity)
        {

            var newUser = new User
            {
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Email = entity.Email,
                UserName = entity.UserName

            };

            await context.Users.AddAsync(newUser);

            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var userToSoftDelete = await context.Users.FirstOrDefaultAsync(u => u.Id == id);

            if (userToSoftDelete is null) return false;

            var entityEntry = context.Users.Update(userToSoftDelete);

            // TODO: sofdelete

            return true;

        }

        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {

            return await context.Users
                .Select(u => u.ConvertToDto())
                .ToListAsync();
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
