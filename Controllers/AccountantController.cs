using E_Vita_APIs.Models;
using E_Vita_APIs.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace E_Vita_APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountantController : ControllerBase
    {
        private readonly IRepositories<Accountant> _accountantRepo;

        public AccountantController(IRepositories<Accountant> accountantRepo)
        {
            _accountantRepo = accountantRepo;
        }

        // GET: api/Accountant
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Accountant>>> GetAllAccountants()
        {
            var accountants = await _accountantRepo.GetAllAsync();
            return Ok(accountants);
        }

        // GET: api/Accountant/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Accountant>> GetAccountant(string id)
        {
            var accountant = await _accountantRepo.GetByIdAsync(id);

            if (accountant == null)
            {
                return NotFound();
            }

            return Ok(accountant);
        }

        // POST: api/Accountant
        [HttpPost]
        public async Task<ActionResult<Accountant>> CreateAccountant([FromBody] Accountant accountant)
        {
            await _accountantRepo.AddAsync(accountant);
            return Ok();
        }

        // PUT: api/Accountant/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAccountant(string id, [FromBody] Accountant accountant)
        {
            try
            {
                await _accountantRepo.UpdateAsync(accountant, id);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // DELETE: api/Accountant/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccountant(string id)
        {
            await _accountantRepo.DeleteAsync(id);
            return Ok();
        }
    }
} 