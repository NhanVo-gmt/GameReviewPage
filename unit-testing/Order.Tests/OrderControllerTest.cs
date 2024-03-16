using OrderManagementSystem.Services;
using Xunit;
using FakeItEasy;
using OrderManagementSystem.Models;
using OrderManagementSystem.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace OrderManagementSystem.Tests 
{
    
    public class OrderControllerTest 
    {
        [Fact]
        public async void GetAllOrdersTest()
        {
        
            var dataStore = A.Fake<IOrderService>();
            var controller = new OrderController(dataStore);

            var actionResult = await controller.GetAllOrders();
            
            var result = actionResult as OkObjectResult;

            Assert.NotEqual(result, null);
            Assert.Equal(200, result.StatusCode);
        }
    }
}


