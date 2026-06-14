using StockCareV2.Application.DTOs;

namespace StockCareV2.Api.Endpoints.Product.GetAll
{
    public class Response
    {
        public IEnumerable<ProductDto> Products { get; set; }
    }
}
