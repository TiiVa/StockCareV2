using StockCareV2.Domain.Entities;

namespace StockCareV2.Application.DTOs
{
    public class OrderProductDto
    {
        public Guid StockId { get; set; }
        public StockDto? Stock { get; set; }
        public Guid ProductId { get; set; }
        public ProductDto? Product { get; set; }
        public int Quantity { get; set; }
        public double OrderSum { get; set; }
    }
}