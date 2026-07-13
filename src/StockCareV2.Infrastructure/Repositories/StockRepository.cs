using Microsoft.EntityFrameworkCore;
using StockCareV2.Application.DTOs;
using StockCareV2.Application.DTOs.Converters;
using StockCareV2.Application.Interfaces.RepositoryInterfaces;
using StockCareV2.Infrastructure.Data;

namespace StockCareV2.Infrastructure.Repositories
{
    public class StockRepository(AppDbContext context) : IStockRepository
    {

        public async Task<IEnumerable<StockDto>> GetAllAsync()
        {
            return await context.Stocks
                .Select(x => x.ConvertToDto()).ToListAsync();
        }

        public async Task<StockDto> GetByIdAsync(Guid id)
        {
            var stock = await context.Stocks.FirstOrDefaultAsync(s => s.Id == id);

            if (stock is null) return new StockDto();

            return stock.ConvertToDto();

        }
        public async Task<bool> AddAsync(StockDto entity)
        {
            var stockModel = entity.ConvertToStock();

            if (stockModel is null) return false;

            await context.Stocks.AddAsync(stockModel);

            await context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateAsync(StockDto entity, Guid id)
        {
            var stockModel = entity.ConvertToStock();
            var stockToUpdate = await context.Stocks.FirstOrDefaultAsync(s => s.Id == id);

            if (stockToUpdate is null) return false;

            stockToUpdate.IsActive = stockModel.IsActive;
            stockToUpdate.SupplierName = stockModel.SupplierName;
            stockToUpdate.ProductsOnStock = stockModel.ProductsOnStock;
            stockToUpdate.Orders = stockModel.Orders;

            await context.SaveChangesAsync();

            return true;

        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var stockToSoftDelete = await context.Stocks.FirstOrDefaultAsync(s => s.Id == id);

            if (stockToSoftDelete is null) return false;

            var entityEntry = context.Stocks.Update(stockToSoftDelete);
            entityEntry.Property(s => s.IsActive).CurrentValue = false;

            await context.SaveChangesAsync();

            return true;
        }




    }
}
