using System.Data.Entity;
using Domain.Entities;

namespace Database.EntityFramework
{
    public class ShopDbContext : DbContext
    {
        public ShopDbContext() : base("ShopSystem")
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var client = modelBuilder.Entity<Client>();
            client.HasKey(c => c.Id);
            client.Property(c => c.FirstName).HasMaxLength(50).IsRequired();
            client.Property(c => c.LastName).HasMaxLength(50).IsRequired();
            client.Property(c => c.BirthDate).HasColumnType("date").IsRequired();

            var seller = modelBuilder.Entity<Seller>();
            seller.HasKey(s => s.Id);
            seller.Property(s => s.FirstName).HasMaxLength(50).IsRequired();
            seller.Property(s => s.LastName).HasMaxLength(50).IsRequired();
            seller.Property(s => s.BirthDate).HasColumnType("date").IsRequired();
            seller.Property(s => s.HireDate).HasColumnType("date").IsRequired();
            seller.Property(s => s.EndDate).HasColumnType("date").IsOptional();

            var product = modelBuilder.Entity<Product>();
            product.HasKey(p => p.Id);
            product.Property(p => p.Name).HasMaxLength(50).IsRequired();
            product.Property(p => p.Price).HasPrecision(5, 2);

            var order = modelBuilder.Entity<Order>();
            order.HasKey(o => o.Id);
            order.Property(o => o.OrderDate).HasColumnType("date").IsRequired();
            order.Property(o => o.ClientId).IsRequired();
            order.Property(o => o.SellerId).IsRequired();
            order.HasRequired(o => o.Client)
                .WithMany(c => c.Orders).HasForeignKey(o => o.ClientId);
            order.HasRequired(o => o.Seller)
                .WithMany(e => e.Orders).HasForeignKey(o => o.SellerId);
            order.HasRequired(o => o.Product)
                .WithMany(p => p.Orders).HasForeignKey(o => o.ProductId);
        }
    }
}