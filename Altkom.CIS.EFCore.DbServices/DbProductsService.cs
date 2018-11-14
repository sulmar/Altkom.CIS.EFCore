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
    }
}
