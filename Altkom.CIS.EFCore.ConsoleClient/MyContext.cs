using Altkom.CIS.EFCore.ConsoleClient.Configurations;
using Altkom.CIS.EFCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Altkom.CIS.EFCore.ConsoleClient
{
    // PM> Install-Package Microsoft.EntityFrameworkCore
    class MyContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products{ get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=ShopDb;Integrated Security=true";

            // PM> Install-Package Microsoft.EntityFrameworkCore.SqlServer
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Mapowanie dziedziczenia do jednej tabeli
            modelBuilder.Entity<Product>().HasBaseType<Item>();
            modelBuilder.Entity<Service>().HasBaseType<Item>();

            // Zdefiniowanie nazwy tabeli
            modelBuilder.Entity<Item>().ToTable("Items");


            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
        
        }

    }
}
