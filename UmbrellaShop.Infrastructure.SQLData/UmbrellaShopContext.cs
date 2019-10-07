using Microsoft.EntityFrameworkCore;
using UmbrellaShop.Core.Entity;
using System;

namespace UmbrellaShop.Infrastructure.SQLData
{
    public class UmbrellaShopContext : DbContext
    {
        public DbSet<Umbrella> Umbrellas { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public UmbrellaShopContext(DbContextOptions<UmbrellaShopContext> opt) : base(opt) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*
            modelBuilder.Entity<Pet>()
                .HasOne(e => e.PreviousOwner)
                .WithMany(c => c.Pets);
              */  
           
        }

    }
}
