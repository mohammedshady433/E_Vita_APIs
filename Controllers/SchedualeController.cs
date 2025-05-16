using E_Vita_APIs.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Vita_APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    
    public class SchedualeController : ControllerBase
    {
        private readonly DBcontext _context;
        public SchedualeController(DBcontext context)
        {
            _context = context;
        }

        [HttpGet]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Scheduale>>> GetAllScheduales()
        {
            var scheduales = await _context.scheduales.ToListAsync();
            return Ok(scheduales);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Scheduale>> GetScheduale(int id)
        {
            var scheduale = await _context.scheduales.FindAsync(id);
            if (scheduale == null)
            {
                return NotFound();
            }
            return Ok(scheduale);
        }

        [HttpPost]
        public async Task<ActionResult<Scheduale>> CreateScheduale(Scheduale scheduale)
        {
            _context.scheduales.Add(scheduale);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetScheduale), new { id = scheduale.Id }, scheduale);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateScheduale(int id, Scheduale scheduale)
        {
            if (id != scheduale.Id)
            {
                return BadRequest();
            }
            _context.Entry(scheduale).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SchedualeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteScheduale(int id)
        {
            var scheduale = await _context.scheduales.FindAsync(id);
            if (scheduale == null)
            {
                return NotFound();
            }
            _context.scheduales.Remove(scheduale);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool SchedualeExists(int id)
        {
            return _context.scheduales.Any(e => e.Id == id);
        }

        [HttpGet("GetSchedualeByAppointmentId/{appointmentId}")]
        public async Task<ActionResult<Scheduale>> GetSchedualeByAppointmentId(int appointmentId)
        {
            var scheduale = await _context.scheduales
                .FirstOrDefaultAsync(s => s.AppointmentId == appointmentId);
            if (scheduale == null)
            {
                return NotFound();
            }
            return Ok(scheduale);
        }

        [HttpGet("GetSchedualeByServiceType/{serviceType}")]
        public async Task<ActionResult<IEnumerable<Scheduale>>> GetSchedualeByServiceType(ServiceType serviceType)
        {
            var scheduales = await _context.scheduales
                .Where(s => s.Service_Type == serviceType)
                .ToListAsync();
            if (scheduales == null || !scheduales.Any())
            {
                return NotFound();
            }
            return Ok(scheduales);
        }
        [HttpGet("GetSchedualeBySpeciality/{speciality}")]
        public async Task<ActionResult<IEnumerable<Scheduale>>> GetSchedualeBySpeciality(MedicalSpecialty speciality)
        {
            var scheduales = await _context.scheduales
                .Where(s => s.speciality == speciality)
                .ToListAsync();
            if (scheduales == null || !scheduales.Any())
            {
                return NotFound();
            }
            return Ok(scheduales);
        }
        [HttpGet("GetSchedualeByActive/{active}")]

        public async Task<ActionResult<IEnumerable<Scheduale>>> GetSchedualeByActive(bool active)
        {
            var scheduales = await _context.scheduales
                .Where(s => s.Active == active)
                .ToListAsync();
            if (scheduales == null || !scheduales.Any())
            {
                return NotFound();
            }
            return Ok(scheduales);
        }

       


    }
}
