using System;
using System.Collections.Generic;
using System.Text;

namespace StockCareV2.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string UserName { get; set; } = null!;
        public string? Email { get; set; }
        public bool IsActive { get; set; }
        public ICollection<Order>? Orders { get; set; } 
    }
}
