using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StockCareV2.Infrastructure.Data;

namespace StockCareV2.Infrastructure
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            //var connectionString = config.GetConnectionString("DefaultConnection");

            //services.AddDbContext<AppDbContext>(options =>
            //{
            //    options.UseSqlServer(connectionString);
            //});

            return services;
        }


    }
}
