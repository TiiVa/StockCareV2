
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StockCareV2.Application.Interfaces.RepositoryInterfaces;
using StockCareV2.Infrastructure.Data;
using StockCareV2.Application;
using StockCareV2.Infrastructure;
using StockCareV2.Application.DTOs;
using StockCareV2.Application.DTOs.Converters;
using FastEndpoints;
using StockCareV2.Application.Interfaces;
using StockCareV2.Infrastructure.UOW;

namespace StockCareV2.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //builder.Services.AddAuthorization();

            // Add services to the container.

            builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            //builder.Services.AddControllers();
            builder.Services
                .AddFastEndpoints(); 
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

            builder.Services.AddApplication()
               .AddInfrastructure(builder.Configuration);

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("BlazorClient", policy =>
                {
                    policy
                        .WithOrigins("https://localhost:7173")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            //builder.Services.AddOpenApi();

            var app = builder.Build();

            //app.MapGet("/products", async ([FromServices] IProductRepository repo) =>
            //{
            //    var products = await repo.GetAllAsync();

            //    return products;
            //});
            //app.MapGet("/products/{id}", async ([FromServices] IProductRepository repo, Guid id) =>
            //{
            //    var product = await repo.GetByIdAsync(id);

            //    return product;
            //});
            //app.MapPost($"/products", async ([FromServices] IProductRepository repo, ProductDto p) =>
            //{
            //    var productEntity = p.ConvertToProduct();

            //    await repo.AddAsync(productEntity);

            //});
            //app.MapPut("/products/{id}", async (IProductRepository repo, Guid id, ProductDto p) =>
            //{
            //    var productEntity = p.ConvertToProduct();
                
            //    await repo.UpdateAsync(productEntity, id);

            //});
            //app.MapDelete("/products/{id}", async (IProductRepository repo, Guid id) => 
            //{
            //    await repo.DeleteAsync(id);
            //});

            // Configure the HTTP request pipeline.

            //if (app.Environment.IsDevelopment())
            //{
            //    app.MapOpenApi();
            //}

            app.UseHttpsRedirection();

            app.UseCors("BlazorClient");

            //app.UseAuthorization();

            app.UseFastEndpoints();
            

            //app.MapControllers();

            app.Run();
        }
    }
}
