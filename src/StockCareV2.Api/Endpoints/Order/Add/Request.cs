using StockCareV2.Application.DTOs;

namespace StockCareV2.Api.Endpoints.Order.Add
{
    public class Request
    {
        public Guid UserId { get; set; }
        public UserDto? User { get; set; }
        public bool IsActive { get; set; }
        public List<Guid>? OrderProductDtoList { get; set; }
    }
}
