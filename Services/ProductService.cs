using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderManagementSystem.Data;
using OrderManagementSystem.Models;
using OrderManagementSystem.Utility;

namespace OrderManagementSystem.Services
{
    public class ProductService : IProductService
    {
        private static List<Product> _products = new List<Product>{
            new Product { Id = 1, Name = "Hollow Knight", Description = "hello..."},
            new Product { Id = 2, Name = "Zelda: Breath of the Wild", Description = "hello..."},
            new Product { Id = 3, Name = "Than Trung", Description = "hello..."}
        };

        OrderManagementDbContext _context;

        public ProductService(OrderManagementDbContext context)
        {
            _context = context;
        }
        
        public async Task<object> GetAllProducts() 
        {
            var data = await _context.Products.ToListAsync();
            return new SuccessResponse( new {data});
        }

        public async Task<object> GetProductById(int id)
        {
            var data = await _context.Products.FirstOrDefaultAsync(item => item.Id == id);
            return new SuccessResponse(new { data });
        }

        public async Task<object> PostProduct(Product product)
        {
            if (product == null) return ErrorCode.PRODUCT_NOT_FOUND;


            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            return new SuccessResponse( new { success = true}); //todo
        }

        public async Task<object> PutProduct(int id, Product updatedProduct)
        {
            if (id != updatedProduct.Id)
            {
                return ErrorCode.ID_INVALID;
            }

            var existingProduct = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (existingProduct == null)
            {
                return ErrorCode.PRODUCT_NOT_FOUND;
            }

            existingProduct.Name = updatedProduct.Name;
            existingProduct.Description = updatedProduct.Description;
            existingProduct.Category = updatedProduct.Category;
            existingProduct.Price = updatedProduct.Price;

            await _context.SaveChangesAsync();

            return new SuccessResponse (new {updatedProduct});
        }

        public async Task<object> DeleteProduct(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (product == null)
            {
                return ErrorCode.PRODUCT_NOT_FOUND;
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return new SuccessResponse( new {_context.Products});
        }
    }
}