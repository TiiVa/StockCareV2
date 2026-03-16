using System;
using System.Collections.Generic;
using System.Text;

namespace StockCareV2.Domain.Entities
{
    public class Stock
    {
        public Guid Id { get; set; }
        public string SupplierName { get; set; } = null!;
        public ICollection<OrderProduct>? ProductsOnStock { get; set; }
        public ICollection<Order>? Orders { get; set; }
    }
}
 