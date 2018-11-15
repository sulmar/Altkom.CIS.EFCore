using Altkom.CIS.EFCore.IServices;
using Altkom.CIS.EFCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Altkom.CIS.EFCore.DbServices
{
    public class DbProductsService : IProductsService
    {
        private ShopContext _context;

        public DbProductsService(ShopContext context)
        {
            _context = context;
        }

        public void Add(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public IEnumerable<Product> Get()
        {
            return _context.Products.ToList();
        }

        public Product Get(int id)
        {
            return _context.Products.Find(id);

            // return _context.Products.First(p=>p.Id == id);
            // return _context.Products.Single(p => p.Id == id);
            // return _context.Products.FirstOrDefault(p=>p.Id == id);
            // return _context.Products.SingleOrDefault(p => p.Id == id);
        }

        public void Remove(int id)
        {
            var product = Get(id);

            _context.Products.Remove(product);
            _context.SaveChanges();
        }

        public void Update(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
        }
    }
}
