using Microsoft.EntityFrameworkCore;
using PulseActiveShop.Dal.Sql.Entities;

namespace PulseActiveShop.Dal.Sql.Contexts
{
    internal partial class ShopContext : BaseContext
    {
        public ShopContext(string connectionString) : base(connectionString)
        {
            if (string.IsNullOrEmpty(connectionString)) throw new ArgumentNullException(nameof(connectionString));
        }

        public virtual DbSet<Address> Addresses { get; set; }

        public virtual DbSet<Basket> Baskets { get; set; }

        public virtual DbSet<BasketItem> BasketItems { get; set; }

        public virtual DbSet<Brand> Brands { get; set; }

        public virtual DbSet<Order> Orders { get; set; }

        public virtual DbSet<OrderItem> OrderItems { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<ProductType> ProductTypes { get; set; }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("Address");

                entity.Property(e => e.City).HasMaxLength(128);
                entity.Property(e => e.Country).HasMaxLength(128);
                entity.Property(e => e.StateOrProvince).HasMaxLength(128);
                entity.Property(e => e.Street).HasMaxLength(128);
                entity.Property(e => e.ZipCode).HasMaxLength(10);

                entity.HasOne(d => d.User).WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Address_User");
            });

            modelBuilder.Entity<Basket>(entity =>
            {
                entity.ToTable("Basket");
            });

            modelBuilder.Entity<BasketItem>(entity =>
            {
                entity.ToTable("BasketItem");

                entity.Property(e => e.UnitPrice).HasColumnType("decimal(18, 4)");

                entity.HasOne(d => d.Basket).WithMany(p => p.Items)
                    .HasForeignKey(d => d.BasketId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BasketItem_Basket");

                entity.HasOne(d => d.Product).WithMany(p => p.BasketItems)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BasketItem_Product");
            });

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.ToTable("Brand");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.Property(e => e.OrderDate).HasColumnType("datetime");

                entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_User");

                entity.HasOne(d => d.ShipToAddress).WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ShipToAddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_Address");
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.ToTable("OrderItem");

                entity.Property(e => e.PictureUri).HasMaxLength(255);
                entity.Property(e => e.ProductName).HasMaxLength(50);
                entity.Property(e => e.UnitPrice).HasColumnType("decimal(18, 4)");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.Description).HasMaxLength(255);
                entity.Property(e => e.Name).HasMaxLength(50);
                entity.Property(e => e.PictureUri).HasMaxLength(255);
                entity.Property(e => e.Price).HasColumnType("decimal(18, 4)");

                entity.HasOne(d => d.Brand).WithMany(p => p.Products)
                    .HasForeignKey(d => d.BrandId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_Brand");

                entity.HasOne(d => d.ProductType).WithMany(p => p.Products)
                    .HasForeignKey(d => d.ProductTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_ProductType");
            });

            modelBuilder.Entity<ProductType>(entity =>
            {
                entity.ToTable("ProductType");

                entity.Property(e => e.Description).HasMaxLength(255);
                entity.Property(e => e.Type).HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Email).HasMaxLength(50);
                entity.Property(e => e.Password).HasMaxLength(128);
                entity.Property(e => e.Username).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
