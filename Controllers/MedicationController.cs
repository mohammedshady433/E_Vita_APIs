using E_Vita_APIs.Models;
using E_Vita_APIs.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Vita_APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicationController : ControllerBase
    {
        private readonly IRepositories<Medication> _repo;

        public MedicationController(IRepositories<Medication> repo)
        {
            _repo = repo;
        }

        // GET: api/medications
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Medication>>> GetAll()
        {
            var meds = await _repo.GetAllAsync();
            return Ok(meds);
        }

        // GET: api/medications/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Medication>> GetById(int id)
        {
            var med = await _repo.GetByIdAsync(id);
            if (med == null ) return NotFound("Medication not found.");
            return Ok(med);
        }

        // POST: api/medications
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Medication medication)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _repo.AddAsync(medication);
            return Ok(medication);
        }

        // PUT: api/medications/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] Medication updatedMedication)
        {
            if (id != updatedMedication.Id)
                return BadRequest("ID mismatch.");

            try
            {
                await _repo.UpdateAsync(updatedMedication, id);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }

            return Ok(updatedMedication);
         
        }

        // DELETE: api/medications/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _repo.DeleteAsync(id);
            return Ok();
        }
    }
}
