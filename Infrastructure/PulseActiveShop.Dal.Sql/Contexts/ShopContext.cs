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

        internal DbSet<Brand> Brands { get; set; }

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
            
            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");
            });            
            
            modelBuilder.Entity<Brand>(entity =>
            {
                entity.ToTable("Brand");
            });            
            
            modelBuilder.Entity<ProductType>(entity =>
            {
                entity.ToTable("ProductType");
            });            
            
            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");
            });            
            
            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.ToTable("OrderItem");
            });            
            
            modelBuilder.Entity<BasketItem>(entity =>
            {
                entity.ToTable("BasketItem");
            });
            
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");
            });


        }
    }
}
