using E_Vita_APIs.Models;
using E_Vita_APIs.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace E_Vita_APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Wardroundcontroller : ControllerBase
    {
        
   
        private readonly IRepositories<WardRound> _context;
        public Wardroundcontroller(IRepositories<WardRound> context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WardRound>>> GetAllWardRounds()
        {
            var wardRounds = await _context.GetAllAsync();
            return Ok(wardRounds);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WardRound>> GetWardRound(string id)
        {
            var wardRound = await _context.GetByIdAsync(id);
            if (wardRound == null)
            {
                return NotFound();
            }
            return Ok(wardRound);
        }

        [HttpPost]
        public async Task<ActionResult<WardRound>> CreateWardRound(WardRound wardRound)
        {
            await _context.AddAsync(wardRound);
            return Ok(wardRound.Id);
        }




        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWardRound(string id)
        {
            var wardRound = await _context.GetByIdAsync(id);
            if (wardRound == null)
            {
                return NotFound();
            }
            await _context.DeleteAsync(id);
            return NoContent();
        }

        
        

        

        

    }
}
