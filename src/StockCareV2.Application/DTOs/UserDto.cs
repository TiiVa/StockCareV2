using StockCareV2.Domain.Entities;

namespace StockCareV2.Application.DTOs
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string UserName { get; set; } = null!;
        public string? Email { get; set; }
        public bool IsActive { get; set; }
        public List<OrderDto>? Orders { get; set; }
    }
}