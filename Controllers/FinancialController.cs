using E_Vita_APIs.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using E_Vita_APIs.Models;


namespace E_Vita_APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinancialController : ControllerBase
    {
        private readonly IRepositories<Financial> _financialRepo;

        public FinancialController(IRepositories<Financial> financialRepo)
        {
            _financialRepo = financialRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _financialRepo.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var record = await _financialRepo.GetByIdAsync(id);
            return record == null ? NotFound() : Ok(record);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Financial financial)
        {
            await _financialRepo.AddAsync(financial);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Financial updated)
        {
            await _financialRepo.UpdateAsync(updated, id);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _financialRepo.DeleteAsync(id);
            return Ok();
        }
    }
}