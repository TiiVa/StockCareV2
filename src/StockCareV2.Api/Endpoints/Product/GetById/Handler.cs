using FastEndpoints;
using StockCareV2.Application.Interfaces;
using StockCareV2.Application.Interfaces.RepositoryInterfaces;

namespace StockCareV2.Api.Endpoints.Product.GetProduct
{
    public class Handler(IUnitOfWork uow) : Endpoint<Request, Response>
    {
        public override void Configure()
        {
            Get("products/{ProductId}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(Request req, CancellationToken ct)
        {

            var product = await uow.ProductRepository.GetByIdAsync(req.ProductId);

            Response = new Response
            {
                Product = product
            };

        }
    }
}
