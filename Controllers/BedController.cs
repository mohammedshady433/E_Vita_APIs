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
        private readonly IRepositories<Bed> _bedRepo;

        public BedController(IRepositories<Bed> bedRepo)
        {
            _bedRepo = bedRepo;
        }

        // GET: api/beds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bed>>> GetBeds()
        {
            var beds = await _bedRepo.GetAllAsync();
            return Ok(beds);
        }

        // GET: api/beds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bed>> GetBed(int id)
        {
            var bed = await _bedRepo.GetByIdAsync(id);

            if (bed == null || bed.Id == 0)
                return NotFound();

            return Ok(bed);
        }

        // POST: api/beds
        [HttpPost]
        public async Task<ActionResult> CreateBed(Bed bed)
        {
            await _bedRepo.AddAsync(bed);
            return Ok();
        }

        // PUT: api/beds/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBed(int id, Bed updatedBed)
        {
            if (id != updatedBed.Id)
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
        public async Task<IActionResult> DeleteBed(int id)
        {
            var bed = await _bedRepo.GetByIdAsync(id);
            if (bed == null || bed.Id == 0)
                return NotFound();

            await _bedRepo.DeleteAsync(id);
            return Ok();
        }
    }
}
    

