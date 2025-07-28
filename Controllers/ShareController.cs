using E_Vita_APIs.Models;
using E_Vita_APIs.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Vita_APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShareController : ControllerBase
    {
        private readonly IRepositories<Share> _repo;

        public ShareController(IRepositories<Share> repo)
        {
            _repo = repo;
        }

        // GET
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var shares = await _repo.GetAllAsync();
            return Ok(shares);
        }

        // GET_BY_ID
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(string id)
        {
            var share = await _repo.GetByIdAsync(id);
            if (share == null)
                return NotFound("Share not found.");

            return Ok(share);
        }

        // POST
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Share share)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _repo.AddAsync(share);
            return Ok(share);
        }

        // PUT
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(string id, [FromBody] Share updatedShare)
        {
            try
            {
                await _repo.UpdateAsync(updatedShare, id);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            return Ok("Share updated successfully.");
        }

        // DELETE
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            await _repo.DeleteAsync(id);
            return Ok("Share deleted successfully.");
        }

        // GET shares by Doctor ID
        [HttpGet("doctor/{doctorId}")]
        public async Task<ActionResult> GetByDoctorId(string doctorId)
        {
            var allShares = await _repo.GetAllAsync();
            var shares = allShares.Where(s => s.DoctorId == doctorId).ToList();
            
            if (!shares.Any())
                return NotFound("No shares found for this doctor.");
                
            return Ok(shares);
        }

        // GET shares by Note ID
        [HttpGet("note/{noteId}")]
        public async Task<ActionResult> GetByNoteId(string noteId)
        {
            var allShares = await _repo.GetAllAsync();
            var shares = allShares.Where(s => s.NoteID == noteId).ToList();
            
            if (!shares.Any())
                return NotFound("No shares found for this note.");
                
            return Ok(shares);
        }

        // GET shares by Nurse ID
        [HttpGet("nurse/{nurseId}")]
        public async Task<ActionResult> GetByNurseId(string nurseId)
        {
            var allShares = await _repo.GetAllAsync();
            var shares = allShares.Where(s => s.NurseID == nurseId).ToList();
            
            if (!shares.Any())
                return NotFound("No shares found for this nurse.");
                
            return Ok(shares);
        }

        // GET shares by Receptionist ID
        [HttpGet("receptionist/{receptionistId}")]
        public async Task<ActionResult> GetByReceptionistId(string receptionistId)
        {
            var allShares = await _repo.GetAllAsync();
            var shares = allShares.Where(s => s.ReceptionistId == receptionistId).ToList();
            
            if (!shares.Any())
                return NotFound("No shares found for this receptionist.");
                
            return Ok(shares);
        }
    }
}