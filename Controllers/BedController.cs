using E_Vita_APIs.Models;
using E_Vita_APIs.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Vita_APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BedController : ControllerBase
    {
        private readonly IRepositories<Beds> _bedRepo;

        public BedController(IRepositories<Beds> bedRepo)
        {
            _bedRepo = bedRepo;
        }

        // GET: api/beds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Beds>>> GetBeds()
        {
            var beds = await _bedRepo.GetAllAsync();
            return Ok(beds);
        }

        // GET: api/beds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Beds>> GetBed(string id)
        {
            var bed = await _bedRepo.GetByIdAsync(id);

            if (bed == null)
                return NotFound();

            return Ok(bed);
        }

        // POST: api/beds
        [HttpPost]
        public async Task<ActionResult> CreateBed([FromBody] Beds bed)
        {
            await _bedRepo.AddAsync(bed);
            return Ok();
        }

        // PUT: api/beds/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBed(string id, [FromBody] Beds updatedBed)
        {
            if (!id.Equals(updatedBed.Id))
                return BadRequest("ID mismatch");

            try
            {
                await _bedRepo.UpdateAsync(updatedBed, id);
                return NoContent();
            }
            catch (ArgumentException)
            {
                return NotFound();
            }
        }

        // DELETE: api/beds/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBed(string id)
        {
            var bed = await _bedRepo.GetByIdAsync(id);
            if (bed == null)
                return NotFound();

            await _bedRepo.DeleteAsync(id);
            return Ok();
        }
    }
}