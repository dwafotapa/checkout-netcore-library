using System.Linq;
using Checkout.ProductApi.NetCore.Models;
using Checkout.ProductApi.NetCore.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Checkout.ProductApi.NetCore.Controllers
{
  [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _repository;

        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }

        // GET api/product/orangina
        [HttpGet("{name}")]
        public IActionResult Get(string name)
        {
            var product = _repository.Find(name);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // GET api/product
        [HttpGet]
        public IActionResult Get()
        {
            var products = _repository.GetAll();
            return Ok(products);
        }

        // POST api/product
        [HttpPost]
        public IActionResult Post(Product p)
        {
            var product = _repository.Find(p.Name);
            if (product == null) {
                product = new Product {
                    Name = p.Name,
                    Quantity = p.Quantity
                };
                _repository.Add(product);
                return Ok(product);
            }

            return BadRequest("Product already exists");
        }

        // PUT api/product/5
        [HttpPut]
        // public void Put(string id, [FromBody]string value)
        public IActionResult Put(Product p)
        {
            var product = _repository.Find(p.Name);
            if (product == null) {
                return NotFound();
            }

            product.Quantity = p.Quantity;
            _repository.Update(product);
            return Ok();
        }

        // DELETE api/product/5
        [HttpDelete("{name}")]
        public IActionResult Delete(string name)
        {
            var product = _repository.Find(name);
            if (product == null) {
                return NotFound();
            }

            _repository.Remove(product);
            return Ok();
        }
    }
}
