using E_Vita_APIs.Models;
using E_Vita_APIs.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace E_Vita_APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionController : ControllerBase
    {
        private readonly IRepositories<Prescription> _prescriptionRepo;

        public PrescriptionController(IRepositories<Prescription> prescriptionRepo)
        {
            _prescriptionRepo = prescriptionRepo;
        }

        // GET: api/Prescription
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Prescription>>> GetAllPrescriptions()
        {
            var prescriptions = await _prescriptionRepo.GetAllAsync();
            return Ok(prescriptions);
        }

        // GET: api/Prescription/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Prescription>> GetPrescription(int id)
        {
            var prescription = await _prescriptionRepo.GetByIdAsync(id);

            if (prescription == null)
            {
                return NotFound();
            }

            return Ok(prescription);
        }

        // POST: api/Prescription
        [HttpPost]
        public async Task<ActionResult<Prescription>> CreatePrescription([FromBody] Prescription prescription)
        {
            await _prescriptionRepo.AddAsync(prescription);
            return Ok();
        }

        // PUT: api/Prescription/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePrescription(int id, [FromBody] Prescription prescription)
        {
            try
            {
                await _prescriptionRepo.UpdateAsync(prescription, id);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // DELETE: api/Prescription/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePrescription(int id)
        {
            await _prescriptionRepo.DeleteAsync(id);
            return Ok();
        }
    }
}
