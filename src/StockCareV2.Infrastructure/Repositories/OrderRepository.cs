using Microsoft.EntityFrameworkCore;
using StockCareV2.Application.DTOs;
using StockCareV2.Application.DTOs.Converters;
using StockCareV2.Application.Interfaces.RepositoryInterfaces;
using StockCareV2.Infrastructure.Data;

namespace StockCareV2.Infrastructure.Repositories
{
    internal class OrderRepository(AppDbContext context) : IOrderRepository
    {

        public async Task<IEnumerable<OrderDto>> GetAllAsync()
        {
            return await context.Orders
                .Select(o => o.ConvertToDto())
                .ToListAsync();
        }

        public async Task<OrderDto> GetByIdAsync(Guid id)
        {
            var order = await context.Orders.FirstOrDefaultAsync(o => o.Id == id);

            if (order is null) return new OrderDto();

            return order.ConvertToDto();
        }

        public async Task<bool> AddAsync(OrderDto entity)
        {
            var orderModel = entity.ConvertToModel();
            var newOrder = await context.Orders.AddAsync(orderModel);

            if (newOrder is null) return false;

            await context.SaveChangesAsync();

            return true;
            
        }
        public async Task<bool> UpdateAsync(OrderDto entity, Guid id)
        {
            var orderToUpdate = await context.Orders.FirstOrDefaultAsync(o => o.Id == id);

            if (orderToUpdate is null) return false;

            orderToUpdate.IsActive = entity.IsActive;
            orderToUpdate.UserId = entity.UserId;

            await context.SaveChangesAsync();

            return true;

        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var orderToSoftDelete = await context.Orders.FirstOrDefaultAsync(o => o.Id == id);

            if (orderToSoftDelete is null) return false;

            var entityEntry = context.Orders.Update(orderToSoftDelete);

            entityEntry.Property(o => o.IsActive).CurrentValue = false;

            return true;
        }
    }
}
