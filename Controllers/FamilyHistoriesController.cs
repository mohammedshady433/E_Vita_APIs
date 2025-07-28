using E_Vita_APIs.Models;
using E_Vita_APIs.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace E_Vita_APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FamilyHistoriesController : ControllerBase
    {
        private readonly IFamilyHistoryRepository _repository;
        public FamilyHistoriesController(IFamilyHistoryRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _repository.GetFamilyHistories();
            return Ok(items);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var item = await _repository.GetFamilyHistory(id);
            if (item == null) return NotFound();
            return Ok(item);
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] FamilyHistory familyHistory)
        {
            await _repository.AddFamilyHistory(familyHistory);
            return Ok(familyHistory);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] FamilyHistory familyHistory)
        {
            if (id != familyHistory.Fam_ID) return BadRequest();
            await _repository.UpdateFamilyHistory(familyHistory);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _repository.DeleteFamilyHistory(id);
            return NoContent();
        }
    }
}
