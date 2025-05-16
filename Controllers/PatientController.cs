using E_Vita_APIs.Models;
using E_Vita_APIs.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;


namespace E_Vita_APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IRepositories<Patient> _patientRepo;

        public PatientController(IRepositories<Patient> patientRepo)
        {
            _patientRepo = patientRepo;
        }

        // GET: api/Patient
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Patient>>> GetAllPatients()
        {
            var patients = await _patientRepo.GetAllAsync();
            return Ok(patients);
        }

        // GET: api/Patient/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Patient>> GetPatient(int id)
        {
            var patient = await _patientRepo.GetByIdAsync(id);

            if (patient == null )
            {
                return NotFound();
            }

            return Ok(patient);
        }

        // POST: api/Patient
        [HttpPost]
        public async Task<ActionResult<Patient>> CreatePatient(Patient patient)
        {
            await _patientRepo.AddAsync(patient);
            return Ok();
        }

        // PUT: api/Patient/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePatient(int id, Patient patient)
        {
            try
            {
                await _patientRepo.UpdateAsync(patient, id);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // DELETE: api/Patient/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatient(int id)
        {
            await _patientRepo.DeleteAsync(id);
            return Ok();
        }
    }
}
