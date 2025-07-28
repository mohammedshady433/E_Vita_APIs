using E_Vita_APIs.Models;
using E_Vita_APIs.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Vita_APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SharedNotesController : ControllerBase
    {
        private readonly ISharedNoteRepository _repository;
        public SharedNotesController(ISharedNoteRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _repository.GetSharedNotes();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var item = await _repository.GetSharedNote(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SharedNote sharedNote)
        {
            await _repository.AddSharedNote(sharedNote);
            return Ok(sharedNote);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] SharedNote sharedNote)
        {
            if (id != sharedNote.Note_ID) return BadRequest();
            await _repository.UpdateSharedNote(sharedNote);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _repository.DeleteSharedNote(id);
            return NoContent();
        }

        [HttpGet("practitioner/{practitionerId}")]
        public async Task<IActionResult> GetByPractitioner(int practitionerId)
        {
            var allSharedNotes = await _repository.GetSharedNotes();
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
