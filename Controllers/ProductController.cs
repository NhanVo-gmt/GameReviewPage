using OrderManagementSystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderManagementSystem.Services;
using OrderManagementSystem.Utility;

namespace OrderManagementSystem.Controllers 
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductService _productService;

        // GET: api/product
        [HttpGet]
        public async Task<IActionResult> GetAllProducts() {
            try
            {
                var data = await _productService.GetAllProducts();
                return Ok(data);
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        // GET: api/producs/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            try
            {
                var product = await _productService.GetProductById(id);
                return Ok(product);
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        // POST: api/product
        [HttpPost]
        public async Task<IActionResult> PostProduct(Product product)
        {
            try
            {
                await _productService.PostProduct(product);
                return CreatedAtAction(nameof(GetProductById), new {id = product.Id}, product);
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product updatedProduct)
        {
            try
            {
                var data = await _productService.PutProduct(id, updatedProduct);
                return Ok(data);
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                var data = await _productService.DeleteProduct(id);
                return Ok(data);
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }
    }
}