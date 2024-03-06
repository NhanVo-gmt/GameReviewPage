using Microsoft.AspNetCore.Mvc;
using OrderManagementSystem.Models;

namespace OrderManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase 
    {
        private static List<OrderDetail> _orderDetails = new List<OrderDetail>{
            new OrderDetail { OrderDetailID = 1, OrderID = 1, ProductID = 1, Quantity = 2},
            new OrderDetail { OrderDetailID = 1, OrderID = 2, ProductID = 2, Quantity = 2},
            new OrderDetail { OrderDetailID = 1, OrderID = 3, ProductID = 3, Quantity = 1},
        };

        private static List<Order> _orders = new List<Order>{
            new Order { OrderID = 1, OrderDetails = _orderDetails}
        }; 

        [HttpGet]
        public ActionResult<IEnumerable<Order>> GetAllOrders()
        {
            if (_orders == null)
            {
                return NotFound();
            }
            return Ok(_orders);
        }

        [HttpGet("{id}")]
        public ActionResult<Order> GetOrderFromId(int id)
        {
            var order = _orders.FirstOrDefault(item => item.OrderID == id);
            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }

        [HttpPost]
        public ActionResult<Order> PostOrder(Order order)
        {
            if (order == null)
            {
                return BadRequest("Order is null");
            }

            order.OrderID = _orders.Count + 1;
            _orders.Add(order);
            return CreatedAtAction(nameof(GetOrderFromId), new {id = order.OrderID}, order);
        }

        [HttpDelete]
        public ActionResult<Order> DeleteOrder(int id)
        {
            var order = _orders.FirstOrDefault(item => item.OrderID == id);
            if (order == null)
            {
                return BadRequest("Order not found");
            }

            _orders.Remove(order);

            return NoContent();
        }
    }
}