using Altkom.CIS.EFCore.IServices;
using Altkom.CIS.EFCore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Altkom.CIS.EFCore.WebService.Controllers
{

    [Route("api/products")]
    [ApiController]
    public class ProductsController : Controller
    {
        private readonly IProductsService _productsService;

        public ProductsController(IProductsService productsService)
        {
            _productsService = productsService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get()
        {
            var products = _productsService.Get();

            return Ok(products);
        }
        
        [HttpGet("{id}")]
        public ActionResult<Product> Find(string id)
        {
            throw new NotImplementedException();
        }

        [HttpGet("{id:int}")]
        public ActionResult<Product> Get(int id)
        {
            var product = _productsService.Get(id);

            if (product==null)
            {
                return NotFound();
            }

            return Ok(product);
        }

      

        [HttpPost]
        public ActionResult Post(Product product)
        {
            _productsService.Add(product);

            return CreatedAtRoute(new { id = product.Id }, product);
        }


        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _productsService.Remove(id);

            return NoContent();
        }



        [HttpPut("{id}")]
        public ActionResult Update(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            _productsService.Update(product);

            return NoContent();
        }

        [Route("/products")]
        public ActionResult Index()
        {
            var products = _productsService.Get();

            return View(products);
        }
    }
}
