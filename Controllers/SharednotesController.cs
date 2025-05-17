using E_Vita_APIs.Models;
using E_Vita_APIs.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Vita_APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SharednotesController : ControllerBase
    {
        private readonly IRepositories<SharedNote> _context;
        public SharednotesController(IRepositories<SharedNote> context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SharedNote>>> GetAllSharedNotes()
        {
            var sharedNotes = await _context.GetAllAsync();
            return Ok(sharedNotes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SharedNote>> GetSharedNote(int id)
        {
            var sharedNote = await _context.GetByIdAsync(id);
            if (sharedNote == null)
            {
                return NotFound();
            }
            return Ok(sharedNote);
        }


        [HttpPost]
        public async Task<ActionResult<SharedNote>> CreateSharedNote(SharedNote sharedNote)
        {
            await _context.AddAsync(sharedNote);
            return Ok();
        }





        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSharedNote(int id)
        {
            var sharedNote = await _context.GetByIdAsync(id);
            if (sharedNote == null)
            {
                return NotFound();
            }
            await _context.DeleteAsync(id);
            return NoContent();
        }

       

        [HttpGet("practitioner/{practitionerId}")]
        public async Task<ActionResult<IEnumerable<SharedNote>>> GetSharedNotesByPractitioner(int practitionerId)
        {
            var allSharedNotes = await _context.GetAllAsync();
            var sharedNotes = allSharedNotes
                .Where(sn => sn.PractitionerID == practitionerId)
                .ToList();
            if (sharedNotes == null || !sharedNotes.Any())
            {
                return NotFound();
            }
            return Ok(sharedNotes);
        }



    }
}
