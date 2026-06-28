using StockCareV2.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockCareV2.Application.DTOs
{
    public class StockDto
    {
        public Guid Id { get; set; }
        public string SupplierName { get; set; } = null!;
        public List<OrderProductDto>? ProductsOnStock { get; set; }
        public List<OrderDto>? Orders { get; set; }
        public bool IsActive { get; set; }
    }
}
