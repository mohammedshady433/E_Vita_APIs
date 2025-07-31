using E_Vita_APIs.Models;
using E_Vita_APIs.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace E_Vita_APIs.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class DaysController : ControllerBase
    {
        private readonly DaysRepo _daysRepo;

        private DaysController(DaysRepo daysRepo)
        {
            _daysRepo = daysRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var days = await _daysRepo.GetAllAsync();
            return Ok(days);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var day = await _daysRepo.GetByIdAsync(id);
            if (day == null)
                return NotFound();

            return Ok(day);
        }

        [HttpPost]
        public async Task<ActionResult> CreateDay([FromBody] Days day)
        {
            await _daysRepo.AddAsync(day);
            return Ok(day);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDay(string id, [FromBody] Days updatedDay)
        {

            try
            {
                await _daysRepo.UpdateAsync(updatedDay, id);
                return Ok();
            }
            catch (ArgumentException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDay(string id)
        {

            await _daysRepo.DeleteAsync(id);
            return Ok();
        }
    }
}