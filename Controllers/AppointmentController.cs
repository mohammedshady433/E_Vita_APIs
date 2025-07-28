using E_Vita_APIs.Models;
using E_Vita_APIs.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Vita_APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IRepositories<Appointment> _appointmentRepo;

        public AppointmentController(IRepositories<Appointment> appointmentRepo)
        {
            _appointmentRepo = appointmentRepo;
        }

        // GET: api/appointments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Appointment>>> GetAppointments()
        {
            var appointments = await _appointmentRepo.GetAllAsync();
            return Ok(appointments);
        }

        // GET: api/appointments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Appointment>> GetAppointment(string id)
        {
            var appointment = await _appointmentRepo.GetByIdAsync(id);

            if (appointment == null )
                return NotFound();

            return Ok(appointment);
        }

        // POST: api/appointments
        [HttpPost]
        public async Task<ActionResult> CreateAppointment([FromBody] Appointment appointment)
        {
            await _appointmentRepo.AddAsync(appointment);
            return Ok();
        }

        // PUT: api/appointments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAppointment(string id, [FromBody] Appointment updatedAppointment)
        {
            if (id != updatedAppointment.Id)
                return BadRequest("ID mismatch");

            try
            {
                await _appointmentRepo.UpdateAsync(updatedAppointment, id);
                return NoContent();
            }
            catch (ArgumentException)
            {
                return NotFound();
            }
        }

        // DELETE: api/appointments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppointment( string id)
        {
            var appointment = await _appointmentRepo.GetByIdAsync(id);

            if (appointment == null)
                return NotFound();

            await _appointmentRepo.DeleteAsync(id);
            return Ok();
        }
    }
}

    

