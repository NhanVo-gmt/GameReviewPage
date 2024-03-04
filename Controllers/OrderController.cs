using OrderManagementSystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OrderManagementSystem.Controllers 
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase 
    {
        private static List<Product> _news = new List<Product>{
            new Product { Id = 1, Title = "Hollow Knight", Description = "hello..."},
            new Product { Id = 1, Title = "Zelda: Breath of the Wild", Description = "hello..."},
            new Product { Id = 1, Title = "Than Trung", Description = "hello..."}
        };

        // GET: api/news
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetAllNews() {
            return _news;
        }

        // GET: api/news/1
        [HttpGet("{id}")]
        public ActionResult<Product> GetNews(int id)
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
        public ActionResult<Product> PostNews(Product news)
        {
            _news.Add(news);
            return CreatedAtAction(nameof(GetNews), new {id = news.Id}, news);
        }
    }
}