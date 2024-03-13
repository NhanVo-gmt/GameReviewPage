using Microsoft.AspNetCore.Mvc;
using OrderManagementSystem.Models;

namespace OrderManagementSystem.Services
{
    public class ProductService : IProductService
    {
        private static List<Product> _products = new List<Product>{
            new Product { Id = 1, Name = "Hollow Knight", Description = "hello..."},
            new Product { Id = 2, Name = "Zelda: Breath of the Wild", Description = "hello..."},
            new Product { Id = 3, Name = "Than Trung", Description = "hello..."}
        };
        
        public Task<object> GetAllProducts() {
            return _products;
        }

        public Task<object> GetProductById(int id)
        {
            return _products.FirstOrDefault(item => item.Id == id);
        }

        public Task<object> PostProduct(Product product)
        {
            if (product == null) return;

            product.Id = _products.Count + 1;

            _products.Add(product);
        }

        public Task<object> PutProduct(int id, Product updatedProduct)
        {
            if (id != updatedProduct.Id)
            {
                return ;
            }

            var existingProduct = _products.FirstOrDefault(p => p.Id == id);
            if (existingProduct == null)
            {
                return ;
            }

            existingProduct.Name = updatedProduct.Name;
            existingProduct.Description = updatedProduct.Description;
            existingProduct.Category = updatedProduct.Category;
            existingProduct.Price = updatedProduct.Price;
        
        }

        public Task<object> DeleteProduct(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return ;
            }

            _products.Remove(product);
        }
    }
}