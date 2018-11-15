using Altkom.CIS.EFCore.DbServices.Configurations;
using Altkom.CIS.EFCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Altkom.CIS.EFCore.DbServices
{
    public class ShopContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public ShopContext(DbContextOptions<ShopContext> options)
            : base(options)
        {
            this.Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // string connectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=ShopDb;Integrated Security=true";

            // PM> Install-Package Microsoft.EntityFrameworkCore.SqlServer
            // optionsBuilder.UseSqlServer(connectionString);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new ItemConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
