using StockCareV2.Application.Interfaces;
using StockCareV2.Application.Interfaces.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockCareV2.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _uow;
        public ProductService(IUnitOfWork uow)
        {
            _uow = uow;
        }


    }
}
