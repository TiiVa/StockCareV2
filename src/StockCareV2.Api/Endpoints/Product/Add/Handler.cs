using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;
using StockCareV2.Application.DTOs;
using StockCareV2.Application.Interfaces;
using StockCareV2.Application.Interfaces.RepositoryInterfaces;

namespace StockCareV2.Api.Endpoints.Product.Add
{
    public class Handler(IUnitOfWork uow) : Endpoint<Request, Results<Ok, BadRequest>>
    {
        public override void Configure()
        {
            Post("/products");
            AllowAnonymous();
        }

        public override async Task<Results<Ok, BadRequest>> HandleAsync(Request req, CancellationToken ct)
        {
            var products = await uow.ProductRepository.GetAllAsync();

            if (products.Any(p => p.Name == req.Name))
            {
                return TypedResults.BadRequest();
            }

            var newProduct = new ProductDto
            {
                Name = req.Name,
                Price = req.Price,
                Quantity = req.Quantity,
                PackageSize = req.Quantity,
                Unit = req.Unit,
                MinStockLevel = req.MinStockLevel,
                IsActive = req.IsActive,
                LastUpdated = req.LastUpdated

            };

            await uow.ProductRepository.AddAsync(newProduct);

            return TypedResults.Ok();
        }
    }
}
