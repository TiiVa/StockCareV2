using StockCareV2.Domain.Enums;

namespace StockCareV2.Domain.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public double Price { get; set; }
        public Unit Unit { get; set; }
        public int PackageSize { get; set; }
        public int Quantity { get; set; }
        public int MinStockLevel { get; set; }
        public bool IsActive { get; set; }
        public DateTime LastUpdated { get; set; }
        public ICollection<Order>? Orders { get; set; }
        public ICollection<Stock>? Stocks { get; set; } // TODO: Remove this?
    }
}
