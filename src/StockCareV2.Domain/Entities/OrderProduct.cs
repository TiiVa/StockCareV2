using System;
using System.Collections.Generic;
using System.Text;

namespace StockCareV2.Domain.Entities
{
    public class OrderProduct
    {
        public Guid StockId { get; set; }
        public Stock? Stock { get; set; }
        public Guid ProductId { get; set; }
        public Product? Product { get; set; }
        public int Quantity { get; set; }
        public double OrderSum { get; set; }    

    }
}
