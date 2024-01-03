using Microsoft.Extensions.Configuration;
using PulseActiveShop.Core.Entities;
using PulseActiveShop.Dal.Sql.Repositories;

namespace PulseActiveShop.Test
{
    internal class Program
    {
        // A practical way to test just the repositories without the overhead of testing the whole stack
        static async Task Main(string[] args)
        {
            IConfiguration Configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
                .AddEnvironmentVariables()
                .AddCommandLine(args)
                .Build();

            //await CreateNewProductAsync(Configuration);

            await CreateNewUserAsync(Configuration);

        }

        private static async Task CreateNewProductAsync(IConfiguration Configuration)
        {
            var product = new Product(
                name: "Warm Socks",
                price: 9.99M,
                productTypeId: 5,
                productTypeName: "",
                brandId: 1,
                brandName: "",
                description: "100% pure wool socks",
                pictureUri: "socks.png");

            var productRepository = new ProductRepository(Configuration);

            var newProduct = await productRepository.AddAsync(product);
            
            Console.WriteLine($"Added new product with id {newProduct?.Id}");
        }

        private static async Task CreateNewUserAsync(IConfiguration configuration)
        {
            var userRepository = new UserRepository(configuration);

            var newUser = await userRepository.AddAsync(new User("Vanni", "TODO", "vanni.boncinelli@remira.com"));

            Console.WriteLine($"Added new user with id {newUser?.Id}");
        }

        private static async Task CreateNewOrder(IConfiguration configuration)
        {
            var productRepository = new ProductRepository(configuration);

            var products = await productRepository.GetAllAsync(1, 5);

            var orderItems = new List<OrderItem>();

            foreach (var product in products)
            {
                orderItems.Add(
                    new OrderItem(
                        new ProductOrdered(ProductId: product.Id, ProductName: product.Name, PictureUri: product.PictureUri),
                        unitPrice: product.Price,
                        units: 1));
            }

            var order = new Order(
                customerId: 1,
                new Address("Sunset Boulevard", "Los Angeles", "California", "USA", "10000"),
                orderItems);
        }
    }
}
