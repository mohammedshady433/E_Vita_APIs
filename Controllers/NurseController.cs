using E_Vita_APIs.Models;
using E_Vita_APIs.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace E_Vita_APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NurseController : ControllerBase
    {
        private readonly IRepositories<Nurse> _nurseRepo;

        public NurseController(IRepositories<Nurse> nurseRepo)
        {
            _nurseRepo = nurseRepo;
        }

        // GET: api/Nurse
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Nurse>>> GetAllNurses()
        {
            var nurses = await _nurseRepo.GetAllAsync();
            return Ok(nurses);
        }

        // GET: api/Nurse/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Nurse>> GetNurse(string id)
        {
            var nurse = await _nurseRepo.GetByIdAsync(id);

            if (nurse == null)
            {
                return NotFound();
            }

            return Ok(nurse);
        }

        // POST: api/Nurse
        [HttpPost]
        public async Task<ActionResult<Nurse>> CreateNurse([FromBody] Nurse nurse)
        {
            await _nurseRepo.AddAsync(nurse);
            return Ok();
        }

        // PUT: api/Nurse/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNurse(string id, [FromBody] Nurse nurse)
        {
            try
            {
                await _nurseRepo.UpdateAsync(nurse, id);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // DELETE: api/Nurse/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNurse(string id)
        {
            await _nurseRepo.DeleteAsync(id);
            return Ok();
        }
    }
} 