using E_Vita_APIs.Models;
using E_Vita_APIs.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Vita_APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    
    public class SchedleController : ControllerBase
    {
        private readonly IRepositories<Scheduale> _context;
        public SchedleController(IRepositories<Scheduale> context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Scheduale>>> GetAllScheduales()
        {
            var scheduales = await _context.GetAllAsync();
            return Ok(scheduales);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Scheduale>> GetScheduale(int id)
        {
            var schedule = await _context.GetByIdAsync(id);
            if (schedule == null)
            {
                return NotFound();
            }
            return Ok(schedule);
        }

        [HttpPost]
        public async Task<ActionResult<Scheduale>> CreateSchedule([FromBody] Scheduale schedule)
        {
            await _context.AddAsync(schedule);
            return Ok(schedule);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSchedule(int id)
        {
            var schedule = await _context.GetByIdAsync(id);
            if (schedule == null)
            {
                return NotFound();
            }
            await _context.DeleteAsync(id);
            return Ok();
        }
    }
}
