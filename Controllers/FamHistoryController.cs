using E_Vita_APIs.Models;
using E_Vita_APIs.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Vita_APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FamHistoryController : ControllerBase
    {
        private readonly IRepositories<FamHistory> _repo;

        public FamHistoryController(IRepositories<FamHistory> repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _repo.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var record = await _repo.GetByIdAsync(id);
            return record == null ? NotFound() : Ok(record);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] FamHistory famHistory)
        {
            await _repo.AddAsync(famHistory);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] FamHistory updated)
        {
            await _repo.UpdateAsync(updated, id);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _repo.DeleteAsync(id);
            return Ok();
        }
    }
}