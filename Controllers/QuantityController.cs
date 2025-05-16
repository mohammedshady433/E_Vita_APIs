using E_Vita_APIs.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using E_Vita_APIs.Models;
namespace E_Vita_APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class QuantityController : ControllerBase
    {
        private readonly QuantityRepo _quantityRepo;
        private QuantityController(QuantityRepo quantityRepo)
        {
            _quantityRepo = quantityRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var quantities = await _quantityRepo.GetAllAsync();
            return Ok(quantities);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var quantity = await _quantityRepo.GetByIdAsync(id);
            if (quantity == null)
            {
                return NotFound();
            }
            return Ok(quantity);
        }
        [HttpPost]
        public async Task<IActionResult> Add(Quantity quantity)
        {
            if (quantity == null)
            {
                return BadRequest("Invalid quantity data.");
            }
            await _quantityRepo.AddAsync(quantity);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var quantity = await _quantityRepo.GetByIdAsync(id);
            if (quantity == null)
            {
                return NotFound();
            }
            await _quantityRepo.DeleteAsync(id);
            return Ok();
        }
    }
}
