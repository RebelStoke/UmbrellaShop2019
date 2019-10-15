using Microsoft.EntityFrameworkCore;
using UmbrellaShop.Core.Entity;
using System;

namespace UmbrellaShop.Infrastructure.SQLData
{
    public class UmbrellaShopContext : DbContext
    {
        public DbSet<Umbrella> Umbrellas { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderUmbrella> OrderUmbrellas { get; set; }

        public UmbrellaShopContext(DbContextOptions<UmbrellaShopContext> opt) : base(opt) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<OrderUmbrella>().HasKey(sc => new { sc.UmbrellaId, sc.OrderId });

            modelBuilder.Entity<OrderUmbrella>()
                .HasOne<Order>(sc => sc.Order)
                .WithMany(s => s.OrderUmbrellas)
                .HasForeignKey(sc => sc.OrderId);


            modelBuilder.Entity<OrderUmbrella>()
                .HasOne<Umbrella>(sc => sc.Umbrella)
                .WithMany(s => s.OrderUmbrellas)
                .HasForeignKey(sc => sc.UmbrellaId);

            modelBuilder.Entity<Order>()
                .HasOne<Customer>(sc => sc.Customer)
                .WithMany(s => s.Orders);
        }

    }
}
