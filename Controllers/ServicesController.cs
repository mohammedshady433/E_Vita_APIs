using E_Vita_APIs.Models;
using E_Vita_APIs.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace E_Vita_APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IServiceRepository _repository;
        public ServicesController(IServiceRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _repository.GetServices();
            return Ok(items);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var item = await _repository.GetService(id);
            if (item == null) return NotFound();
            return Ok(item);
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Service service)
        {
            await _repository.AddService(service);
            return Ok(service);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Service service)
        {
            if (id != service.Service_ID) return BadRequest();
            await _repository.UpdateService(service);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _repository.DeleteService(id);
            return NoContent();
        }
    }
}
