using StockCareV2.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockCareV2.Application.DTOs
{
    public class OrderDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public User? User { get; set; }

        // TODO: Add OrderProductDto list
    }
}
