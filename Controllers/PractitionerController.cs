using E_Vita_APIs.Models;
using E_Vita_APIs.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace E_Vita_APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PractitionerController : ControllerBase
    {
        private readonly IRepositories<Practitioner> _practitionerRepo;

        public PractitionerController(IRepositories<Practitioner> practitionerRepo)
        {
            _practitionerRepo = practitionerRepo;
        }

        // GET: api/Practitioner
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Practitioner>>> GetAllPractitioners()
        {
            var practitioners = await _practitionerRepo.GetAllAsync();
            return Ok(practitioners);
        }

        // GET: api/Practitioner/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Practitioner>> GetPractitioner(int id)
        {
            var practitioner = await _practitionerRepo.GetByIdAsync(id);

            if (practitioner == null)
            {
                return NotFound();
            }

            return Ok(practitioner);
        }

        // POST: api/Practitioner
        [HttpPost]
        public async Task<ActionResult<Practitioner>> CreatePractitioner(Practitioner practitioner)
        {
            await _practitionerRepo.AddAsync(practitioner);
            return Ok();
        }

        // PUT: api/Practitioner/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePractitioner(int id, Practitioner practitioner)
        {
            try
            {
                await _practitionerRepo.UpdateAsync(practitioner, id);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // DELETE: api/Practitioner/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePractitioner(int id)
        {
            await _practitionerRepo.DeleteAsync(id);
            return Ok();
        }
    }
}
