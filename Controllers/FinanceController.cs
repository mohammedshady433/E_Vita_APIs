using E_Vita_APIs.Models;
using E_Vita_APIs.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace E_Vita_APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinanceController : ControllerBase
    {
        private readonly FinanceRepo _financeRepo;

        private FinanceController(FinanceRepo financeRepo)
        {
            _financeRepo = financeRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var finances = await _financeRepo.GetAllAsync();
            return Ok(finances);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        { 
            var finance = await _financeRepo.GetByIdAsync(id);
            if (finance == null)
                return NotFound();

            return Ok(finance);
        }

        [HttpPost]
        public async Task<ActionResult> CreateFinance([FromBody] Finance finance)
        {
            await _financeRepo.AddAsync(finance);
            return Ok(finance);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFinance(string id, [FromBody] Finance updatedFinance)
        {
            try
            {
                await _financeRepo.UpdateAsync(updatedFinance, id);
                return Ok();
            }
            catch (ArgumentException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFinance(string id)
        {
            await _financeRepo.DeleteAsync(id);
            return Ok();
        }
    }
}