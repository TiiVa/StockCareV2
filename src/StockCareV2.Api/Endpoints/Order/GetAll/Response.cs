using StockCareV2.Application.DTOs;

namespace StockCareV2.Api.Endpoints.Order.GetAll
{
    public class Response
    {
        public IEnumerable<OrderDto> Orders { get; set; }
    }
}
