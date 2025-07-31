using E_Vita_APIs.Models;
using E_Vita_APIs.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_Vita_APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IRepositories<Service> _repo;

        public ServicesController(IRepositories<Service> repo)
        {
            _repo = repo;
        }

        // GET: api/Services
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Service>>> GetAll()
        {
            var services = await _repo.GetAllAsync();
            return Ok(services);
        }

        // GET: api/Services/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Service>> GetById(string id)
        {
            var service = await _repo.GetByIdAsync(id);
            if (service == null)
                return NotFound();
            return Ok(service);
        }

        // POST: api/Services
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Service service)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _repo.AddAsync(service);
            return Ok(service);
        }

        // PUT: api/Services/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] Service service)
        {
            if (!id.Equals(service.Service_ID))
                return BadRequest("ID mismatch.");

            try
            {
                await _repo.UpdateAsync(service, id);
                return Ok("Service updated successfully.");
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // DELETE: api/Services/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var service = await _repo.GetByIdAsync(id);
            if (service == null)
                return NotFound();

            await _repo.DeleteAsync(id);
            return Ok("Service deleted successfully.");
        }
    }
}
