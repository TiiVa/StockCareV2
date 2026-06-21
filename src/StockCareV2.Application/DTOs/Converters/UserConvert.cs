using StockCareV2.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockCareV2.Application.DTOs.Converters
{
    public static class UserConvert
    {
        public static UserDto ConvertToDto(this User user)
        {
            var d = new UserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                UserName = user.UserName,
                Orders = user.Orders.Select(o => new OrderDto()
                {
                    Id = o.Id,
                    UserId = o.UserId

                }).ToList()
            };

            return d;
        }
    }
}
