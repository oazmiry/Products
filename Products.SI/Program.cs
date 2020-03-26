using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Products.BL;

namespace Products.SI
{
    internal static class Program
    {
        /// <summary>
        /// The program's entry point.
        /// <remarks>This method is blocking</remarks>
        /// </summary>
        internal static void Main(string[] args)
        {
            var webHost = CreateWebHostBuilder(args).Build();
            webHost.Services.GetRequiredService<IProductsBusinessLogic>().InitApp();
            webHost.Run();
        }

        private static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
