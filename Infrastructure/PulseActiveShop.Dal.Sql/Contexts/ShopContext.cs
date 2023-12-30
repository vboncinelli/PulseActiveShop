using Microsoft.EntityFrameworkCore;
using PulseActiveShop.Dal.Sql.Entities;

namespace PulseActiveShop.Dal.Sql.Contexts
{
    internal class ShopContext : BaseContext
    {
        public ShopContext(string connectionString) : base(connectionString)
        {
            if (string.IsNullOrEmpty(connectionString)) throw new ArgumentNullException(nameof(connectionString));
        }

        internal DbSet<Basket> Baskets { get; set; }

        internal DbSet<Product> Products { get; set; }

        internal DbSet<ProductBrand> ProductBrands { get; set; }

        internal DbSet<ProductType> ProductTypes { get; set; }

        internal DbSet<Order> Orders { get; set; }

        internal DbSet<OrderItem> OrderItems { get; set; }

        internal DbSet<BasketItem> BasketItems { get; set; }

        internal DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Basket>(entity =>
            {
                entity.ToTable("Basket");
            });
        }
    }
}
