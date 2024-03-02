using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Game_review_project.Controllers 
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase 
    {
        [HttpGet]
        public string Get() {
            return "Returning";
        }
    }
}