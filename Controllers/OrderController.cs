using OrderManagementSystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OrderManagementSystem.Controllers 
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase 
    {
        private static List<OrderModel> _news = new List<OrderModel>{
            new OrderModel { Id = 1, Title = "Hollow Knight", Description = "hello..."},
            new OrderModel { Id = 1, Title = "Zelda: Breath of the Wild", Description = "hello..."},
            new OrderModel { Id = 1, Title = "Than Trung", Description = "hello..."}
        };

        // GET: api/news
        [HttpGet]
        public ActionResult<IEnumerable<OrderModel>> GetAllNews() {
            return _news;
        }

        // GET: api/news/1
        [HttpGet("{id}")]
        public ActionResult<OrderModel> GetNews(int id)
        {
            var news = _news.FirstOrDefault(item => item.Id == id);
            if (news == null)
            {
                return NotFound();
            }

            return news;
        }

        // POST: api/news
        [HttpPost]
        public ActionResult<OrderModel> PostNews(OrderModel news)
        {
            _news.Add(news);
            return CreatedAtAction(nameof(GetNews), new {id = news.Id}, news);
        }
    }
}