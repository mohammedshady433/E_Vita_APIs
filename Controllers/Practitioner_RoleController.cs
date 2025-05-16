using E_Vita_APIs.Models;
using E_Vita_APIs.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace E_Vita_APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Practitioner_RoleController : ControllerBase
    {
        private readonly IRepositories<Practitioner_Role> _practitionerRoleRepo;

        public Practitioner_RoleController(IRepositories<Practitioner_Role> practitionerRoleRepo)
        {
            _practitionerRoleRepo = practitionerRoleRepo;
        }

        // GET: api/Practitioner_Role
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Practitioner_Role>>> GetAllPractitionerRoles()
        {
            var practitionerRoles = await _practitionerRoleRepo.GetAllAsync();
            return Ok(practitionerRoles);
        }

        // GET: api/Practitioner_Role/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Practitioner_Role>> GetPractitionerRole(int id)
        {
            var practitionerRole = await _practitionerRoleRepo.GetByIdAsync(id);

            if (practitionerRole == null)
            {
                return NotFound();
            }

            return Ok(practitionerRole);
        }

        // POST: api/Practitioner_Role
        [HttpPost]
        public async Task<ActionResult<Practitioner_Role>> CreatePractitionerRole([FromBody] Practitioner_Role practitionerRole)
        {
            await _practitionerRoleRepo.AddAsync(practitionerRole);
            return Ok();
        }

        // PUT: api/Practitioner_Role/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePractitionerRole(int id, [FromBody] Practitioner_Role practitionerRole)
        {
            try
            {
                await _practitionerRoleRepo.UpdateAsync(practitionerRole, id);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // DELETE: api/Practitioner_Role/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePractitionerRole(int id)
        {
            await _practitionerRoleRepo.DeleteAsync(id);
            return Ok();
        }
    }
}
