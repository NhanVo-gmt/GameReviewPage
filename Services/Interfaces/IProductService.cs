using Microsoft.AspNetCore.Mvc;
using OrderManagementSystem.Models;

namespace OrderManagementSystem.Services
{
    public interface IProductService
    {
        Task<object> GetAllProducts();
        Task<object> GetProductById(int id);
        Task<object> PostProduct(Product product);
        Task<object> PutProduct(int id, Product updatedProduct);
        Task<object> DeleteProduct(int id);
    }
}