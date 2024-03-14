using Microsoft.EntityFrameworkCore;
using OrderManagementSystem.Contexts;
using OrderManagementSystem.Models;
using OrderManagementSystem.Utility;

namespace OrderManagementSystem.Services
{
    public class OrderService : IOrderService
    {
        private OrderManagementContext _context;

        public OrderService(OrderManagementContext context)
        {
            _context = context;
        }

        public async Task<object> DeleteOrder(int id)
        {
            var data = await _context.Orders.FirstOrDefaultAsync(item => item.OrderID == id);
            if (data == null) return ErrorCode.ORDER_NOT_FOUND;

            _context.Orders.Remove(data);
            await _context.SaveChangesAsync();

            return new SuccessResponse(new { success = true });
        }

        public async Task<object> GetAllOrders()
        {
            var data = await _context.Orders.ToListAsync();
            return new SuccessResponse ( new { data });
        }

        public async Task<object> GetOrderById(int id)
        {
            var data = await _context.Orders.FirstOrDefaultAsync(item => item.OrderID == id);
            return new SuccessResponse( new { data });
        }

        public async Task<object> PostOrder(Order order)
        {
            if (order == null) return ErrorCode.ORDER_NOT_FOUND;

            Order lastOrder = await _context.Orders.LastAsync();
            order.OrderID = lastOrder.OrderID + 1;
            
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            return new SuccessResponse(new { success = true });
        }
    }
}