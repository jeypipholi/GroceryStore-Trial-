using GroceryStore.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GroceryStore.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories  { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Product>()
                    .HasOne(p => p.Category)
                    .WithMany(c => c.Products)
                    .HasForeignKey(k => k.CategoryID);

            builder.Entity<Product>()
                   .HasOne(p => p.Supplier)
                   .WithMany(s => s.Products)
                   .HasForeignKey(k => k.SupplierID);

            builder.Entity<Order>()
                    .HasOne(c => c.Customer)
                    .WithMany(O => O.Orders)
                    .HasForeignKey(k => k.CustomerID);

            builder.Entity<OrderDetail>()
                   .HasKey(p => p.OrderDetailsID);

            builder.Entity<OrderDetail>()
                   .HasOne(o => o.Order)
                   .WithMany(d => d.OrderDetails)
                   .HasForeignKey(k => k.OrderID);

            builder.Entity<OrderDetail>()
                   .HasOne(p => p.Product)
                   .WithMany(o => o.OrderDetails)
                   .HasForeignKey(k => k.ProductID);

            builder.Entity<Order>(entity =>
            {
                entity.Property(t => t.TotalAmount)
                .HasPrecision(10, 2);
            });

            builder.Entity<Product>(entity =>
            {
                entity.Property(p => p.Price)
                      .HasPrecision(10, 2);
            });

            builder.Entity<OrderDetail>(entity =>
            {
                entity.Property(s => s.Subtotal)
                      .HasPrecision(10, 2);
            });
                   
        }
    }
}
