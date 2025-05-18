using E_Vita_APIs.Models;
using E_Vita_APIs.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_Vita_APIs.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentPractitionerController : ControllerBase
    {
        private readonly AppointmentPractitionerRepo _repo;

        public AppointmentPractitionerController(AppointmentPractitionerRepo repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppointmentPractitioner>>> GetAll()
        {
            var result = await _repo.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{practitionerId:int}")]
        public async Task<ActionResult<IEnumerable<AppointmentPractitioner>>> GetById(int practitionerId)
        {
            var result = await _repo.GetByPractitionerIdAsync(practitionerId);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] AppointmentPractitioner entity)
        {
            await _repo.AddAsync(entity);
            return CreatedAtAction(nameof(GetById), new { appointmentId = entity.AppointmentId, practitionerId = entity.PractitionersId }, entity);
        }

        [HttpPut("{appointmentId:int}/{practitionerId:int}")]
        public async Task<ActionResult> Update(int appointmentId, int practitionerId, [FromBody] AppointmentPractitioner entity)
        {
            await _repo.UpdateAsync(entity, appointmentId, practitionerId);
            return NoContent();
        }

        [HttpDelete("{appointmentId:int}/{practitionerId:int}")]
        public async Task<ActionResult> Delete(int appointmentId, int practitionerId)
        {
            await _repo.DeleteAsync(appointmentId, practitionerId);
            return NoContent();
        }
    }
}
