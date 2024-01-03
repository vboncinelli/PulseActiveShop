using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using PulseActiveShop.Dal.Sql.Repositories;

namespace PulseActiveShop.Test
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            IConfiguration Configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
                .AddEnvironmentVariables()
                .AddCommandLine(args)
                .Build();

            // A practical way to test just the repository without the overhead of testing the whole stack
            var orderRepository = new OrderRepository(Configuration);
            
            var order = await orderRepository.FindAsync(1);

            Console.WriteLine(order is null ? "not found": order.Id);
        }
    }
}
