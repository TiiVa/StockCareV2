using FastEndpoints;
using StockCareV2.Application.Interfaces;

namespace StockCareV2.Api.Endpoints.Product.GetAll
{
    public class Handler(IUnitOfWork uow) : Endpoint<EmptyRequest, Response>
    {
        public override void Configure()
        {
            Get("/products");
            AllowAnonymous();
        }

        public override async Task HandleAsync(EmptyRequest req, CancellationToken ct)
        {
            var products = await uow.ProductRepository.GetAllAsync();

            Response = new Response
            {
                Products = products
            };


        }
    }
}
