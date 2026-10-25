using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;
using StockCareV2.Application.DTOs;
using StockCareV2.Application.Interfaces;
using StockCareV2.Application.Interfaces.RepositoryInterfaces;

namespace StockCareV2.Api.Endpoints.Order.Add
{
    public class Handler(IUnitOfWork uow) : Endpoint<Request, Results<Ok, NotFound>>
    {
        public override void Configure()
        {
            Post("/orders");
            AllowAnonymous();
        }

        public override async Task<Results<Ok, NotFound>> HandleAsync(Request req, CancellationToken ct)
        {
            var order = new OrderDto
            {
                UserId = req.UserId,
                IsActive = true,
                OrderProductDtoList = req.OrderProductDtoList
            };

            if(order.UserId == Guid.Empty)
            {
                return TypedResults.NotFound();
            }

            await uow.OrderRepository.AddAsync(order);

            return TypedResults.Ok();
            
        }
    }
}
