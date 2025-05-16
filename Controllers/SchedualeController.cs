using E_Vita_APIs.Models;
using E_Vita_APIs.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Vita_APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    
    public class SchedualeController : ControllerBase
    {
        private readonly IRepositories<Scheduale> _context;
        public SchedualeController(IRepositories<Scheduale> context)
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
            var scheduale = await _context.GetByIdAsync(id);
            if (scheduale == null)
            {
                return NotFound();
            }
            return Ok(scheduale);
        }

        [HttpPost]
        public async Task<ActionResult<Scheduale>> CreateScheduale(Scheduale scheduale)
        {
            _context.AddAsync(scheduale);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteScheduale(int id)
        {
            var scheduale = await _context.GetByIdAsync(id);
            if (scheduale == null)
            {
                return NotFound();
            }
            await _context.DeleteAsync(id);
            return Ok();
        }
    }
}
