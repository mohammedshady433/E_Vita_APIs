using E_Vita_APIs.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using E_Vita_APIs.Models;
namespace E_Vita_APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultsController : ControllerBase
    {
        private readonly IRepositories<Models.Results> _resultsRepo;
        public ResultsController(IRepositories<Models.Results> resultsRepo)
        {
            _resultsRepo = resultsRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var results = await _resultsRepo.GetAllAsync();
            return Ok(results);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var results = await _resultsRepo.GetByIdAsync(id);
            if (results == null)
            {
                return NotFound();
            }
            return Ok(results);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Models.Results results)
        {
            if (results == null)
            {
                return BadRequest("Invalid results data.");
            }
            await _resultsRepo.AddAsync(results);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var results = await _resultsRepo.GetByIdAsync(id);
            if (results == null)
            {
                return NotFound();
            }
            await _resultsRepo.DeleteAsync(id);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Models.Results updatedResults)
        {
            if (updatedResults == null)
            {
                return BadRequest("Invalid results data.");
            }
            try
            {
                await _resultsRepo.UpdateAsync(updatedResults, id);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }


    }
}
