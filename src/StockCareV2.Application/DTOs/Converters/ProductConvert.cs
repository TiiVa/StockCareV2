using StockCareV2.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockCareV2.Application.DTOs.Converters
{
    public static class ProductConvert
    {
        public static ProductDto ConvertToDto(this Product product)
        {
            var d = new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Unit = product.Unit,
                PackageSize = product.PackageSize,
                Quantity = product.Quantity,
                MinStockLevel = product.MinStockLevel,
                LastUpdated = product.LastUpdated

            };

            return d;
        }

        public static Product ConvertToProduct(this ProductDto d)
        {
            var m = new Product
            {
                Id = d.Id,
                Name = d.Name,
                Price = d.Price,
                Unit = d.Unit,
                MinStockLevel = d.MinStockLevel,
                LastUpdated = d.LastUpdated,
                IsActive = d.IsActive,
                Quantity = d.Quantity,
                PackageSize = d.PackageSize
                


            };

            return m;
        }
    }
}
