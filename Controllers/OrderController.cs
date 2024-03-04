using OrderManagementSystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OrderManagementSystem.Controllers 
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase 
    {
        private static List<Product> _products = new List<Product>{
            new Product { Id = 1, Name = "Hollow Knight", Description = "hello..."},
            new Product { Id = 1, Name = "Zelda: Breath of the Wild", Description = "hello..."},
            new Product { Id = 1, Name = "Than Trung", Description = "hello..."}
        };

        // GET: api/products
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetAllProducts() {
            return _products;
        }

        // GET: api/products/1
        [HttpGet("{id}")]
        public ActionResult<Product> GetProduct(int id)
        {
            var news = _products.FirstOrDefault(item => item.Id == id);
            if (news == null)
            {
                return NotFound();
            }

            return news;
        }

        // POST: api/products
        [HttpPost]
        public ActionResult<Product> PostProduct(Product product)
        {
            if (product == null)
            {
                return BadRequest("Product is null.");
            }

            product.Id = _products.Count + 1;

            _products.Add(product);
            return CreatedAtAction(nameof(GetProduct), new {id = product.Id}, product);
        }
    }
}