using StockCareV2.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockCareV2.Application.Interfaces.ServiceInterfaces
{
    public interface IProductService : IService<ProductDto, Guid>
    {
       
    }
}
