using E_Vita_APIs.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Vita_APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SharednotesController : ControllerBase
    {
        private readonly DBcontext _context;
        public SharednotesController(DBcontext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SharedNote>>> GetAllSharedNotes()
        {
            var sharedNotes = await _context.SharedNotes.ToListAsync();
            return Ok(sharedNotes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SharedNote>> GetSharedNote(int id)
        {
            var sharedNote = await _context.SharedNotes.FindAsync(id);
            if (sharedNote == null)
            {
                return NotFound();
            }
            return Ok(sharedNote);
        }


        [HttpPost]
        public async Task<ActionResult<SharedNote>> CreateSharedNote(SharedNote sharedNote)
        {
            _context.SharedNotes.Add(sharedNote);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetSharedNote), new { id = sharedNote.Id }, sharedNote);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSharedNote(int id, SharedNote sharedNote)
        {
            if (id != sharedNote.Id)
            {
                return BadRequest();
            }
            _context.Entry(sharedNote).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SharedNoteExists(id))
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
        public async Task<IActionResult> DeleteSharedNote(int id)
        {
            var sharedNote = await _context.SharedNotes.FindAsync(id);
            if (sharedNote == null)
            {
                return NotFound();
            }
            _context.SharedNotes.Remove(sharedNote);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool SharedNoteExists(int id)
        {
            return _context.SharedNotes.Any(e => e.Id == id);
        }

        [HttpGet("practitioner/{practitionerId}")]
        public async Task<ActionResult<IEnumerable<SharedNote>>> GetSharedNotesByPractitioner(int practitionerId)
        {
            var sharedNotes = await _context.SharedNotes
                .Where(sn => sn.PractitionerID == practitionerId)
                .ToListAsync();
            if (sharedNotes == null || !sharedNotes.Any())
            {
                return NotFound();
            }
            return Ok(sharedNotes);
        }



    }
}
