using StockCareV2.Domain.Enums;

namespace StockCareV2.Api.Endpoints.Product.Update
{
    public class Request
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; } = string.Empty;
        public double Price { get; set; }
        public Unit Unit { get; set; }
        public int PackageSize { get; set; }
        public int Quantity { get; set; }
        public int MinStockLevel { get; set; }
        public bool IsActive { get; set; }
    }
}
