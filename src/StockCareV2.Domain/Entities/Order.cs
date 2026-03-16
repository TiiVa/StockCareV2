using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace StockCareV2.Domain.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public User? User { get; set; }
        public ICollection<OrderProduct> Products { get; set; } = [];


    }
}
    