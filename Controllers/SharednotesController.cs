using E_Vita_APIs.Models;
using E_Vita_APIs.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Vita_APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SharedNotesController : ControllerBase
    {
        private readonly IRepositories<SharedNote> _repo;

        public SharedNotesController(IRepositories<SharedNote> repo)
        {
            _repo = repo;
        }

        // GET: api/SharedNotes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SharedNote>>> GetAll()
        {
            var notes = await _repo.GetAllAsync();
            return Ok(notes);
        }

        // GET: api/SharedNotes/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<SharedNote>> GetById(string id)
        {
            var note = await _repo.GetByIdAsync(id);
            if (note == null)
                return NotFound();
            return Ok(note);
        }

        // POST: api/SharedNotes
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] SharedNote note)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _repo.AddAsync(note);
            return Ok(note);
        }

        // PUT: api/SharedNotes/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] SharedNote note)
        {
            if (!id.Equals(note.Note_ID))
                return BadRequest("ID mismatch.");

            try
            {
                await _repo.UpdateAsync(note, id);
                return Ok("SharedNote updated successfully.");
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // DELETE: api/SharedNotes/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var note = await _repo.GetByIdAsync(id);
            if (note == null)
                return NotFound();

            await _repo.DeleteAsync(id);
            return Ok("SharedNote deleted successfully.");
        }

        // GET: api/SharedNotes/practitioner/{practitionerId}
        [HttpGet("practitioner/{practitionerId}")]
        public async Task<IActionResult> GetByPractitioner(string practitionerId)
        {
            var allSharedNotes = await _repo.GetAllAsync();
            var sharedNotes = allSharedNotes
                .Where(sn => sn.practitionerID == practitionerId)
                .ToList();
            if (!sharedNotes.Any())
            {
                return NotFound();
            }
            return Ok(sharedNotes);
        }
    }
}