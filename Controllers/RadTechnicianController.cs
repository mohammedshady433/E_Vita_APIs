using E_Vita_APIs.Models;
using E_Vita_APIs.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace E_Vita_APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RadTechnicianController : ControllerBase
    {
        private readonly IRepositories<Rad_technician> _radTechnicianRepo;

        public RadTechnicianController(IRepositories<Rad_technician> radTechnicianRepo)
        {
            _radTechnicianRepo = radTechnicianRepo;
        }

        // GET: api/RadTechnician
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rad_technician>>> GetAllRadTechnicians()
        {
            var radTechnicians = await _radTechnicianRepo.GetAllAsync();
            return Ok(radTechnicians);
        }

        // GET: api/RadTechnician/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Rad_technician>> GetRadTechnician(string id)
        {
            var radTechnician = await _radTechnicianRepo.GetByIdAsync(id);

            if (radTechnician == null)
            {
                return NotFound();
            }

            return Ok(radTechnician);
        }

        // POST: api/RadTechnician
        [HttpPost]
        public async Task<ActionResult<Rad_technician>> CreateRadTechnician([FromBody] Rad_technician radTechnician)
        {
            await _radTechnicianRepo.AddAsync(radTechnician);
            return Ok();
        }

        // PUT: api/RadTechnician/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRadTechnician(string id, [FromBody] Rad_technician radTechnician)
        {
            try
            {
                await _radTechnicianRepo.UpdateAsync(radTechnician, id);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // DELETE: api/RadTechnician/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRadTechnician(string id)
        {
            await _radTechnicianRepo.DeleteAsync(id);
            return Ok();
        }
    }
} 