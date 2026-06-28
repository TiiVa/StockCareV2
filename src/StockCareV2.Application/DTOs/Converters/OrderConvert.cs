using StockCareV2.Domain.Entities;

namespace StockCareV2.Application.DTOs.Converters
{
    public static class OrderConvert
    {
        public static OrderDto ConvertToDto(this Order order)
        {
            var d = new OrderDto
            {
                Id = order.Id,
                UserId = order.UserId,
                IsActive = order.IsActive

            };

            return d;
        }

        public static Order ConvertToModel(this OrderDto orderDto)
        {
            var m = new Order
            {
                Id = orderDto.Id,
                UserId = orderDto.UserId,
                IsActive = orderDto.IsActive,
            };



            return m;
        }
    }
}
