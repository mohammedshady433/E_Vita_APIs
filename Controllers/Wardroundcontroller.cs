using E_Vita_APIs.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace E_Vita_APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Wardroundcontroller : ControllerBase
    {
        private readonly DBcontext _context;
        public Wardroundcontroller(DBcontext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<WardRound>>> GetAllWardRounds()
        {
            var wardRounds = await _context.WardRounds.ToListAsync();
            return Ok(wardRounds);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WardRound>> GetWardRound(int id)
        {
            var wardRound = await _context.WardRounds.FindAsync(id);
            if (wardRound == null)
            {
                return NotFound();
            }
            return Ok(wardRound);
        }

        [HttpPost]
        public async Task<ActionResult<WardRound>> CreateWardRound(WardRound wardRound)
        {
            _context.WardRounds.Add(wardRound);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetWardRound), new { id = wardRound.Id }, wardRound);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateWardRound(int id, WardRound wardRound)
        {
            if (id != wardRound.Id)
            {
                return BadRequest();
            }
            _context.Entry(wardRound).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WardRoundExists(id))
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
        public async Task<IActionResult> DeleteWardRound(int id)
        {
            var wardRound = await _context.WardRounds.FindAsync(id);
            if (wardRound == null)
            {
                return NotFound();
            }
            _context.WardRounds.Remove(wardRound);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool WardRoundExists(int id)
        {
            return _context.WardRounds.Any(e => e.Id == id);
        }

        [HttpGet("practitioner/{practitionerId}")]
        public async Task<ActionResult<IEnumerable<WardRound>>> GetWardRoundsByPractitioner(int practitionerId)
        {
            var wardRounds = await _context.WardRounds
                .Where(w => w.PractitionerID == practitionerId)
                .ToListAsync();
            if (wardRounds == null || !wardRounds.Any())
            {
                return NotFound();
            }
            return Ok(wardRounds);
        }

        [HttpGet("date/{date}")]
        public async Task<ActionResult<IEnumerable<WardRound>>> GetWardRoundsByDate(DateTime date)
        {
            var wardRounds = await _context.WardRounds
                .Where(w => w.Date.Date == date.Date)
                .ToListAsync();
            if (wardRounds == null || !wardRounds.Any())
            {
                return NotFound();
            }
            return Ok(wardRounds);
        }

        [HttpGet("time/{time}")]
        public async Task<ActionResult<IEnumerable<WardRound>>> GetWardRoundsByTime(TimeOnly time)
        {
            var wardRounds = await _context.WardRounds
                .Where(w => w.Time == time)
                .ToListAsync();
            if (wardRounds == null || !wardRounds.Any())
            {
                return NotFound();
            }
            return Ok(wardRounds);
        }

        [HttpGet("note/{note}")]
        public async Task<ActionResult<IEnumerable<WardRound>>> GetWardRoundsByNote(string note)
        {
            var wardRounds = await _context.WardRounds
                .Where(w => w.Note.Contains(note))
                .ToListAsync();
            if (wardRounds == null || !wardRounds.Any())
            {
                return NotFound();
            }
            return Ok(wardRounds);
        }

        [HttpGet("practitioner/{practitionerId}/date/{date}")]
        public
            async Task<ActionResult<IEnumerable<WardRound>>> GetWardRoundsByPractitionerAndDate(int practitionerId, DateTime date)
        {
            var wardRounds = await _context.WardRounds
                .Where(w => w.PractitionerID == practitionerId && w.Date.Date == date.Date)
                .ToListAsync();
            if (wardRounds == null || !wardRounds.Any())
            {
                return NotFound();
            }
            return Ok(wardRounds);
        }

        [HttpGet("practitioner/{practitionerId}/time/{time}")]
        public
            async Task<ActionResult<IEnumerable<WardRound>>> GetWardRoundsByPractitionerAndTime(int practitionerId, TimeOnly time)
        {
            var wardRounds = await _context.WardRounds
                .Where(w => w.PractitionerID == practitionerId && w.Time == time)
                .ToListAsync();
            if (wardRounds == null || !wardRounds.Any())
            {
                return NotFound();
            }
            return Ok(wardRounds);
        }

        [HttpGet("practitioner/{practitionerId}/note/{note}")]
        public
            async Task<ActionResult<IEnumerable<WardRound>>> GetWardRoundsByPractitionerAndNote(int practitionerId, string note)
        {
            var wardRounds = await _context.WardRounds
                .Where(w => w.PractitionerID == practitionerId && w.Note.Contains(note))
                .ToListAsync();
            if (wardRounds == null || !wardRounds.Any())
            {
                return NotFound();
            }
            return Ok(wardRounds);
        }

        [HttpGet("date/{date}/time/{time}")]
        public
            async Task<ActionResult<IEnumerable<WardRound>>> GetWardRoundsByDateAndTime(DateTime date, TimeOnly time)
        {
            var wardRounds = await _context.WardRounds
                .Where(w => w.Date.Date == date.Date && w.Time == time)
                .ToListAsync();
            if (wardRounds == null || !wardRounds.Any())
            {
                return NotFound();
            }
            return Ok(wardRounds);
        }

        [HttpGet("date/{date}/note/{note}")]
        public
            async Task<ActionResult<IEnumerable<WardRound>>> GetWardRoundsByDateAndNote(DateTime date, string note)
        {
            var wardRounds = await _context.WardRounds
                .Where(w => w.Date.Date == date.Date && w.Note.Contains(note))
                .ToListAsync();
            if (wardRounds == null || !wardRounds.Any())
            {
                return NotFound();
            }
            return Ok(wardRounds);
        }

        [HttpGet("time/{time}/note/{note}")]
        public
            async Task<ActionResult<IEnumerable<WardRound>>> GetWardRoundsByTimeAndNote(TimeOnly time, string note)
        {
            var wardRounds = await _context.WardRounds
                .Where(w => w.Time == time && w.Note.Contains(note))
                .ToListAsync();
            if (wardRounds == null || !wardRounds.Any())
            {
                return NotFound();
            }
            return Ok(wardRounds);
        }

        [HttpGet("practitioner/{practitionerId}/date/{date}/time/{time}")]
        public
            async Task<ActionResult<IEnumerable<WardRound>>> GetWardRoundsByPractitionerDateAndTime(int practitionerId, DateTime date, TimeOnly time)
        {
            var wardRounds = await _context.WardRounds
                .Where(w => w.PractitionerID == practitionerId && w.Date.Date == date.Date && w.Time == time)
                .ToListAsync();
            if (wardRounds == null || !wardRounds.Any())
            {
                return NotFound();
            }
            return Ok(wardRounds);
        }

        [HttpGet("practitioner/{practitionerId}/date/{date}/note/{note}")]
        public
            async Task<ActionResult<IEnumerable<WardRound>>> GetWardRoundsByPractitionerDateAndNote(int practitionerId, DateTime date, string note)
        {
            var wardRounds = await _context.WardRounds
                .Where(w => w.PractitionerID == practitionerId && w.Date.Date == date.Date && w.Note.Contains(note))
                .ToListAsync();
            if (wardRounds == null || !wardRounds.Any())
            {
                return NotFound();
            }
            return Ok(wardRounds);
        }

        [HttpGet("practitioner/{practitionerId}/time/{time}/note/{note}")]
        public
            async Task<ActionResult<IEnumerable<WardRound>>> GetWardRoundsByPractitionerTimeAndNote(int practitionerId, TimeOnly time, string note)
        {
            var wardRounds = await _context.WardRounds
                .Where(w => w.PractitionerID == practitionerId && w.Time == time && w.Note.Contains(note))
                .ToListAsync();
            if (wardRounds == null || !wardRounds.Any())
            {
                return NotFound();
            }
            return Ok(wardRounds);
        }


    }
}
