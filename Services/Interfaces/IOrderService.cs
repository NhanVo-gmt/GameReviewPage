using Microsoft.AspNetCore.Mvc;
using OrderManagementSystem.Models;

namespace OrderManagementSystem.Services
{
    public interface IOrderService
    {
        Task<object> GetAllOrders();
        Task<object> GetOrderById(int id);
        Task<object> PostOrder(Order order);
        Task<object> DeleteOrder(int id);
    }
}