using E_Vita_APIs.Models;
using E_Vita_APIs.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace E_Vita_APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceptionistController : ControllerBase
    {
        private readonly IRepositories<Receptionist> _receptionistRepo;

        public ReceptionistController(IRepositories<Receptionist> receptionistRepo)
        {
            _receptionistRepo = receptionistRepo;
        }

        // GET: api/Receptionist
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Receptionist>>> GetAllReceptionists()
        {
            var receptionists = await _receptionistRepo.GetAllAsync();
            return Ok(receptionists);
        }

        // GET: api/Receptionist/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Receptionist>> GetReceptionist(string id)
        {
            var receptionist = await _receptionistRepo.GetByIdAsync(id);

            if (receptionist == null)
            {
                return NotFound();
            }

            return Ok(receptionist);
        }

        // POST: api/Receptionist
        [HttpPost]
        public async Task<ActionResult<Receptionist>> CreateReceptionist([FromBody] Receptionist receptionist)
        {
            await _receptionistRepo.AddAsync(receptionist);
            return Ok();
        }

        // PUT: api/Receptionist/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReceptionist(string id, [FromBody] Receptionist receptionist)
        {
            try
            {
                await _receptionistRepo.UpdateAsync(receptionist, id);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // DELETE: api/Receptionist/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReceptionist(string id)
        {
            await _receptionistRepo.DeleteAsync(id);
            return Ok();
        }
    }
} 