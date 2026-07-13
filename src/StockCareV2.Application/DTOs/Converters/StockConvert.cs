using StockCareV2.Domain.Entities;


namespace StockCareV2.Application.DTOs.Converters
{
    public static class StockConvert
    {
        public static StockDto ConvertToDto(this Stock stock)
        {
            var d = new StockDto
            {
                Id = stock.Id,
                IsActive = stock.IsActive,
                SupplierName = stock.SupplierName,
                ProductsOnStock = stock.ProductsOnStock.Select(x => new OrderProductDto
                {
                    ProductId = x.ProductId,
                    StockId = x.StockId,
                    OrderSum = x.OrderSum,
                    Quantity = x.Quantity
                }).ToList()
            };

            if (stock.Orders is not null) d.Orders = stock.Orders.Select(x => x.ConvertToDto()).ToList();


            return d;
        }

        public static Stock ConvertToStock(this StockDto d)
        {
            var stockModel = new Stock()
            {
                IsActive = d.IsActive,
                SupplierName = d.SupplierName,
                 
            };

            if (d.ProductsOnStock is null) stockModel.ProductsOnStock = new List<OrderProduct>();
            if (d.Orders is null) stockModel.Orders = new List<Order>();

            return stockModel;
        }

       
    }
}
