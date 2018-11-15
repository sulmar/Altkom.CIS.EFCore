using Altkom.CIS.EFCore.Models;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Altkom.CIS.EFCore.IServices
{
    public interface IProductsService
    {
        IEnumerable<Product> Get();
        Product Get(int id);
        void Add(Product product);
        void Remove(int id);
        void Update(Product product);
    }
}
