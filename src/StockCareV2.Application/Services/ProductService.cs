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
        private readonly HttpClient _httpClient;


        //public ProductService(IHttpClientFactory httpClientFactory, IUnitOfWork uow)
        //{
        //    _uow = uow;
        //    _httpClient = httpClientFactory.CreateClient("OrderHandlerApi");
        //}


    }
}
