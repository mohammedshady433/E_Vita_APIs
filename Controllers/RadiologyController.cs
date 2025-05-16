using E_Vita_APIs.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using E_Vita_APIs.Models;

namespace E_Vita_APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RadiologyController : ControllerBase
    {
        private readonly RadiologyRepo _radiologyRepo;
        public RadiologyController(RadiologyRepo radiologyRepo)
        {
            _radiologyRepo = radiologyRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var radiologies = await _radiologyRepo.GetAllAsync();
            return Ok(radiologies);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var radiology = await _radiologyRepo.GetByIdAsync(id);
            if (radiology == null)
            {
                return NotFound();
            }
            return Ok(radiology);
        }
        [HttpPost]
        public async Task<IActionResult> Add(Radiology radiology)
        {
            if (radiology == null)
            {
                return BadRequest("Invalid radiology data.");
            }
            await _radiologyRepo.AddAsync(radiology);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var radiology = await _radiologyRepo.GetByIdAsync(id);
            if (radiology == null)
            {
                return NotFound();
            }
            await _radiologyRepo.DeleteAsync(id);
            return Ok();
        }
    }
}
