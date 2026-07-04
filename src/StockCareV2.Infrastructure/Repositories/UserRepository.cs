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
        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {

            return await context.Users
                .Select(u => u.ConvertToDto())
                .ToListAsync();
        }

        public async Task<UserDto> GetByIdAsync(Guid id)
        {
            var user = await context.Users.FindAsync(id);

            if (user is null)
            {
                return new UserDto();
            }

            return user.ConvertToDto();
        }
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

             

        public async Task<bool> UpdateAsync(UserDto entity, Guid id)
        {
            var userToUpdate = await context.Users.FirstOrDefaultAsync(u => u.Id == id);

            if (userToUpdate is null) return false;

            userToUpdate.FirstName = entity.FirstName;
            userToUpdate.LastName = entity.LastName;
            userToUpdate.UserName = entity.UserName;
            userToUpdate.IsActive = entity.IsActive;
            userToUpdate.Email = entity.Email;

            await context.SaveChangesAsync();

            return true;
        }
        public async Task<bool> DeleteAsync(Guid id)
        {
            var userToSoftDelete = await context.Users.FirstOrDefaultAsync(u => u.Id == id);

            if (userToSoftDelete is null) return false;

            var entityEntry = context.Users.Update(userToSoftDelete);

            entityEntry.Property(u => u.IsActive).CurrentValue = false;

            return true;

        }
    }
}
