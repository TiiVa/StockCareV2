using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;
using StockCareV2.Application.Interfaces.RepositoryInterfaces;

namespace StockCareV2.Api.Endpoints.Product.Update
{
    public class Handler(IProductRepository repo) : Endpoint<Request, Results<Ok, BadRequest>>
    {
        public override void Configure()
        {
            Put("/products/{ProductId}");
            AllowAnonymous();
        }

        public override async Task<Results<Ok, BadRequest>> ExecuteAsync(Request req, CancellationToken ct)
        {
            var productToUpdate = await repo.GetByIdAsync(req.ProductId);

            if (productToUpdate.Id == Guid.Empty)
            {
                return TypedResults.BadRequest();
            }

            productToUpdate.Name = req.Name;
            productToUpdate.Price = req.Price;
            productToUpdate.Unit = req.Unit;
            productToUpdate.PackageSize = req.PackageSize;
            productToUpdate.MinStockLevel = req.MinStockLevel;
            productToUpdate.Quantity = req.Quantity;
            productToUpdate.IsActive = req.IsActive;

            await repo.UpdateAsync(productToUpdate, req.ProductId);

            return TypedResults.Ok();
        }
    }
}
