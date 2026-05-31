using FastEndpoints;
using StockCareV2.Application.DTOs;
using StockCareV2.Application.Interfaces.RepositoryInterfaces;

namespace StockCareV2.Api.Endpoints.Product.GetProduct
{
    public class Handler(IProductRepository repo) : Endpoint<Request, Response>
    {
        public override void Configure()
        {
            Get("products/{id}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(Request req, CancellationToken ct)
        {

            var product = await repo.GetByIdAsync(req.ProductId);

            Response = new Response
            {
                Product = product
            };

        }
    }
}
