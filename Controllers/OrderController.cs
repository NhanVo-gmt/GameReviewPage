using Microsoft.AspNetCore.Mvc;
using OrderManagementSystem.Models;
using OrderManagementSystem.Services;

namespace OrderManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IOrderService _orderService;

        public OrderController (IOrderService orderService)
        {
            _orderService = orderService;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            try
            {
                var data = await _orderService.GetAllOrders();
                return Ok(data);
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            try
            {
                var data = await _orderService.GetOrderById(id);
                return Ok(data);
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostOrder(Order order)
        {
            try
            {
                await _orderService.PostOrder(order);
                return CreatedAtAction(nameof(GetOrderById), new {id = order.OrderID}, order);
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            try
            {
                var data = await _orderService.DeleteOrder(id);
                return Ok(data);
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }
    }
}