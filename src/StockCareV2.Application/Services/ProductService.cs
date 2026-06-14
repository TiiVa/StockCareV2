using StockCareV2.Application.DTOs;
using StockCareV2.Application.Interfaces;
using StockCareV2.Application.Interfaces.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text;

namespace StockCareV2.Application.Services
{
    public class ProductService : IProductService
    {
        
        private readonly HttpClient _httpClient;


        public ProductService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("StockCareV2Api");
        }

        public Task AddAsync(ProductDto entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            var response = await _httpClient.GetAsync("/products");

            if (!response.IsSuccessStatusCode)
            {
                return Enumerable.Empty<ProductDto>();
            }

            var result = await response.Content.ReadFromJsonAsync<ProductDtoList>();
            return result.Products ?? Enumerable.Empty<ProductDto>();
        }

        public Task<ProductDto> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(ProductDto entity, Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
