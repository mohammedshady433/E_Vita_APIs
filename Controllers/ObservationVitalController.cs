using E_Vita_APIs.Models;
using E_Vita_APIs.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Vita_APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ObservationVitalController : ControllerBase
    {
        private readonly IRepositories<Observation_Vital> _repo;

        public ObservationVitalController(IRepositories<Observation_Vital> repo)
        {
            _repo = repo;
        }

        // GET
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var vitals = await _repo.GetAllAsync();
            return Ok(vitals);
        }

        // GET_BY_ID
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var vital = await _repo.GetByIdAsync(id);
            if (vital == null )
                return NotFound("Observation vital not found.");

            return Ok(vital);
        }

        // POST
        [HttpPost]
        public async Task<ActionResult> Create(Observation_Vital vital)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _repo.AddAsync(vital);
            return Ok(vital); 
        }

        // PUT
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id,  Observation_Vital updatedVital)
        {
            if (id != updatedVital.Id)
                return BadRequest("ID mismatch.");

            try
            {
                await _repo.UpdateAsync(updatedVital, id);
                return Ok("Observation vital updated successfully.");
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message); 
            }
        }

        // DELETE
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _repo.DeleteAsync(id);
            return Ok("Observation vital deleted successfully.");
        }
    }
}

