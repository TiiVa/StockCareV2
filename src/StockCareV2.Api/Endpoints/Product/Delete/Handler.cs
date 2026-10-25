using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;
using StockCareV2.Application.Interfaces;
using StockCareV2.Application.Interfaces.RepositoryInterfaces;

namespace StockCareV2.Api.Endpoints.Product.Delete
{
    public class Handler(IUnitOfWork uow) : Endpoint<Request, Results<Ok, NotFound>>
    {
        public override void Configure()
        {
            Delete("/products/{id}");
            AllowAnonymous();
        }

        public override async Task<Results<Ok,NotFound>> HandleAsync(Request req, CancellationToken ct)
        {
            var product = await uow.ProductRepository.GetByIdAsync(req.Id);

            if(product.Id == Guid.Empty)
            {
                return TypedResults.NotFound();
            }

            await uow.ProductRepository.DeleteAsync(product.Id);

            return TypedResults.Ok();

        }
    }
}
