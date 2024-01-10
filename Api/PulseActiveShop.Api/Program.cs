
using PulseActiveShop.Application.Services;
using PulseActiveShop.Application.Services.Utilities;
using PulseActiveShop.Core.Interfaces.Repository;
using PulseActiveShop.Core.Interfaces.Services;
using PulseActiveShop.Dal.Sql.Repositories;

namespace PulseActiveShop.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            // Just for development, real scenarios should
            // have stricter rules
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddSingleton<IOrderRepository, OrderRepository>();
            builder.Services.AddSingleton<IProductRepository, ProductRepository>();
            builder.Services.AddSingleton<IBrandRepository, BrandRepository>();
            builder.Services.AddSingleton<IProductTypeRepository, ProductTypeRepository>();
            builder.Services.AddSingleton<IBasketRepository, BasketRepository>();

            builder.Services.AddSingleton<IUriComposer, UriComposer>();

            builder.Services.AddSingleton<IOrderService, OrderService>();
            builder.Services.AddSingleton<IProductService, ProductService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseExceptionHandler("/error-development");
            }
            else
            {
                app.UseExceptionHandler("/error");
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
