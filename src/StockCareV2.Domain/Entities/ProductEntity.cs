using StockCareV2.Domain.Enums;

namespace StockCareV2.Domain.Entities
{
    public class ProductEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Unit Unit { get; set; }
        public int PackageSize { get; set; }
        public int Quantity { get; set; }
        public int MinStockLevel { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
