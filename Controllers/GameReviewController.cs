using Game_review_project.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Game_review_project.Controllers 
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase 
    {
        private static List<GameNewsModel> _news = new List<GameNewsModel>{
            new GameNewsModel { Id = 1, Title = "Hollow Knight", Description = "hello...", Category = Category.Indie},
            new GameNewsModel { Id = 1, Title = "Zelda: Breath of the Wild", Description = "hello...", Category = Category.Tripple_A},
            new GameNewsModel { Id = 1, Title = "Than Trung", Description = "hello...", Category = Category.Indie}
        };

        // GET: api/news
        [HttpGet]
        public ActionResult<IEnumerable<GameNewsModel>> GetAllNews() {
            return _news;
        }

        // GET: api/news/1
        [HttpGet("{id}")]
        public ActionResult<GameNewsModel> GetNews(int id)
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
        public ActionResult<GameNewsModel> PostNews(GameNewsModel news)
        {
            _news.Add(news);
            return CreatedAtAction(nameof(GetNews), new {id = news.Id}, news);
        }
    }
}