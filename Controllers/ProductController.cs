using OrderManagementSystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderManagementSystem.Services;

namespace OrderManagementSystem.Controllers 
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase, IProductService
    {
        private static List<Product> _products = new List<Product>{
            new Product { Id = 1, Name = "Hollow Knight", Description = "hello..."},
            new Product { Id = 2, Name = "Zelda: Breath of the Wild", Description = "hello..."},
            new Product { Id = 3, Name = "Than Trung", Description = "hello..."}
        };

        // GET: api/product
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetAllProducts() {
            return _products;
        }

        // GET: api/producs/1
        [HttpGet("{id}")]
        public ActionResult<Product> GetProductById(int id)
        {
            var product = _products.FirstOrDefault(item => item.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // POST: api/product
        [HttpPost]
        public ActionResult<Product> PostProduct(Product product)
        {
            if (product == null)
            {
                return BadRequest("Product is null.");
            }

            product.Id = _products.Count + 1;

            _products.Add(product);
            return CreatedAtAction(nameof(GetProductById), new {id = product.Id}, product);
        }

        [HttpPut("{id}")]
        public ActionResult<Product> PutProduct(int id, Product updatedProduct)
        {
            if (id != updatedProduct.Id)
            {
                return BadRequest();
            }

            var existingProduct = _products.FirstOrDefault(p => p.Id == id);
            if (existingProduct == null)
            {
                return NotFound();
            }

            existingProduct.Name = updatedProduct.Name;
            existingProduct.Description = updatedProduct.Description;
            existingProduct.Category = updatedProduct.Category;
            existingProduct.Price = updatedProduct.Price;
            
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<Product> DeleteProduct(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            _products.Remove(product);

            return NoContent();
        }
    }
}