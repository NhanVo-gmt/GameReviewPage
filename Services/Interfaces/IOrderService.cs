using Microsoft.AspNetCore.Mvc;
using OrderManagementSystem.Models;

namespace OrderManagementSystem.Services
{
    public interface IOrderService
    {
        ActionResult<IEnumerable<Order>> GetAllOrders();
        ActionResult<Order> GetOrderById(int id);
        ActionResult<Order> PostOrder(Order Order);
        ActionResult<Order> PutOrder(int id, Order updatedOrder);
        ActionResult<Order> DeleteOrder(int id);
    }
}