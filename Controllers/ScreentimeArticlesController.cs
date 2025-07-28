using E_Vita_APIs.Models;
using E_Vita_APIs.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace E_Vita_APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScreentimeArticlesController : ControllerBase
    {
        private readonly IScreentimeArticleRepository _repository;
        public ScreentimeArticlesController(IScreentimeArticleRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _repository.GetScreentimeArticles();
            return Ok(items);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var item = await _repository.GetScreentimeArticle(id);
            if (item == null) return NotFound();
            return Ok(item);
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ScreentimeArticle screentimeArticle)
        {
            await _repository.AddScreentimeArticle(screentimeArticle);
            return Ok(screentimeArticle);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ScreentimeArticle screentimeArticle)
        {
            if (id != screentimeArticle.Chat_ID) return BadRequest();
            await _repository.UpdateScreentimeArticle(screentimeArticle);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _repository.DeleteScreentimeArticle(id);
            return NoContent();
        }
    }
}
