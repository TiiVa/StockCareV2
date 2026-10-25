using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;
using StockCareV2.Application.Interfaces;
using StockCareV2.Application.Interfaces.RepositoryInterfaces;

namespace StockCareV2.Api.Endpoints.Order.GetAll
{
    public class Handler(IUnitOfWork uow) : Endpoint<EmptyRequest, Response>
    {
        public override void Configure()
        {
            Get("/orders");
            AllowAnonymous();
        }

        public override async Task HandleAsync(EmptyRequest req, CancellationToken ct)
        {
            var orders = await uow.OrderRepository.GetAllAsync();

            Response = new Response
            {
                Orders = orders,
            };
        }
    }
}
