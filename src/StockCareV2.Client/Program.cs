using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using StockCareV2.Application;
using StockCareV2.Application.Interfaces.ServiceInterfaces;
using StockCareV2.Application.Services;
using StockCareV2.Infrastructure;


namespace StockCareV2.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddScoped<IProductService, ProductService>();


            //builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddHttpClient("StockCareV2Api", o => o.BaseAddress = new Uri("https://localhost:7160"));

           

            await builder.Build().RunAsync();
        }
    }
}
