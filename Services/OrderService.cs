using Microsoft.EntityFrameworkCore;
using OrderManagementSystem.Data;
using OrderManagementSystem.Models;
using OrderManagementSystem.Utility;

namespace OrderManagementSystem.Services
{
    public class OrderService : IOrderService
    {
        private static List<OrderDetail> _orderDetails = new List<OrderDetail>{
            new OrderDetail { OrderDetailID = 1, OrderID = 1, ProductID = 1, Quantity = 2},
            new OrderDetail { OrderDetailID = 1, OrderID = 2, ProductID = 2, Quantity = 2},
            new OrderDetail { OrderDetailID = 1, OrderID = 3, ProductID = 3, Quantity = 1},
        };

        private static List<Order> _orders = new List<Order>{
            new Order { OrderID = 1, OrderStatus = OrderStatus.Pending, OrderDetails = _orderDetails}
        };
        
        private OrderManagementDbContext _context;

        public OrderService(OrderManagementDbContext context)
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