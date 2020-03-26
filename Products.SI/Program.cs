using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

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
            CreateWebHostBuilder(args).Build().Run();
        }

        private static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
