using Microsoft.AspNetCore.Mvc;
using OrderManagementSystem.Models;

namespace OrderManagementSystem.Services
{
    public interface IProductService
    {
        ActionResult<IEnumerable<Product>> GetAllProducts();
        ActionResult<Product> GetProductById(int id);
        ActionResult<Product> PostProduct(Product product);
        ActionResult<Product> PutProduct(int id, Product updatedProduct);
        ActionResult<Product> DeleteProduct(int id);
    }
}