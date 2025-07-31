using E_Vita_APIs.Models;
using E_Vita_APIs.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_Vita_APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScreentimeArticlesController : ControllerBase
    {
        private readonly IRepositories<ScreentimeArticle> _repo;

        public ScreentimeArticlesController(IRepositories<ScreentimeArticle> repo)
        {
            _repo = repo;
        }

        // GET: api/ScreentimeArticles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ScreentimeArticle>>> GetAll()
        {
            var articles = await _repo.GetAllAsync();
            return Ok(articles);
        }

        // GET: api/ScreentimeArticles/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ScreentimeArticle>> GetById(string id)
        {
            var article = await _repo.GetByIdAsync(id);
            if (article == null)
                return NotFound();
            return Ok(article);
        }

        // POST: api/ScreentimeArticles
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] ScreentimeArticle article)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _repo.AddAsync(article);
            return Ok(article);
        }

        // PUT: api/ScreentimeArticles/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] ScreentimeArticle article)
        {
            if (!id.Equals(article.Chat_ID))
                return BadRequest("ID mismatch.");

            try
            {
                await _repo.UpdateAsync(article, id);
                return Ok("ScreentimeArticle updated successfully.");
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // DELETE: api/ScreentimeArticles/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var article = await _repo.GetByIdAsync(id);
            if (article == null)
                return NotFound();

            await _repo.DeleteAsync(id);
            return Ok("ScreentimeArticle deleted successfully.");
        }
    }
}
