
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StockCareV2.Application.Interfaces.RepositoryInterfaces;
using StockCareV2.Infrastructure.Data;
using StockCareV2.Application;
using StockCareV2.Infrastructure;
using StockCareV2.Application.DTOs;

namespace StockCareV2.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

           

            // Add services to the container.

            builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

            builder.Services.AddApplication()
                .AddInfrastructure(builder.Configuration);

            builder.Services.AddOpenApi();

            var app = builder.Build();

            app.MapGet("/products", async ([FromServices] IProductRepository repo) =>
            {
                var products = await repo.GetAllAsync();

                return products;
            });
            app.MapPost($"/products", async ([FromServices] IProductRepository repo, ProductDto p) =>
            {
                //await repo.AddAsync(p); // Add Converters
            });

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
