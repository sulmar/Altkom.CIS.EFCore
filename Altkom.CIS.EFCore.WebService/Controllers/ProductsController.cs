using Altkom.CIS.EFCore.IServices;
using Altkom.CIS.EFCore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Altkom.CIS.EFCore.WebService.Controllers
{
    public class ProductsController : Controller
    {
        private IProductsService _productsService;

        public ProductsController(IProductsService productsService)
        {
            _productsService = productsService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get()
        {
            // throw new NotImplementedException();

            var products = _productsService.Get();

            return Ok(products);
            
            
        }
    }
}
