using E_Vita_APIs.Models;
using E_Vita_APIs.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace E_Vita_APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LabTechnicianController : ControllerBase
    {
        private readonly IRepositories<Lab_technician> _labTechnicianRepo;

        public LabTechnicianController(IRepositories<Lab_technician> labTechnicianRepo)
        {
            _labTechnicianRepo = labTechnicianRepo;
        }

        // GET: api/LabTechnician
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Lab_technician>>> GetAllLabTechnicians()
        {
            var labTechnicians = await _labTechnicianRepo.GetAllAsync();
            return Ok(labTechnicians);
        }

        // GET: api/LabTechnician/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Lab_technician>> GetLabTechnician(string id)
        {
            var labTechnician = await _labTechnicianRepo.GetByIdAsync(id);

            if (labTechnician == null)
            {
                return NotFound();
            }

            return Ok(labTechnician);
        }

        // POST: api/LabTechnician
        [HttpPost]
        public async Task<ActionResult<Lab_technician>> CreateLabTechnician([FromBody] Lab_technician labTechnician)
        {
            await _labTechnicianRepo.AddAsync(labTechnician);
            return Ok();
        }

        // PUT: api/LabTechnician/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLabTechnician(string id, [FromBody] Lab_technician labTechnician)
        {
            try
            {
                await _labTechnicianRepo.UpdateAsync(labTechnician, id);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // DELETE: api/LabTechnician/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLabTechnician(string id)
        {
            await _labTechnicianRepo.DeleteAsync(id);
            return Ok();
        }
    }
} 