using E_Vita_APIs.Models;
using E_Vita_APIs.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;

namespace E_Vita_APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EncounterController : ControllerBase
    {
        private readonly EncounterRepo _encounterRepo;

        private EncounterController(EncounterRepo encounterRepo)
        {
            _encounterRepo = encounterRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var encounters = await _encounterRepo.GetAllAsync();
            return Ok(encounters);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var encounter = await _encounterRepo.GetByIdAsync(id);
            if (encounter == null)
                return NotFound();

            return Ok(encounter);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Encounter encounter)
        {
            await _encounterRepo.AddAsync(encounter);
            return Ok(encounter);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Encounter updated)
        {
            try
            {
                await _encounterRepo.UpdateAsync(updated, id);
                return Ok(); 
            }
            catch (ArgumentException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _encounterRepo.DeleteAsync(id);
            return Ok();
        }
    }
}
