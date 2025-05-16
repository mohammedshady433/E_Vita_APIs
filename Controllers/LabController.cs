using E_Vita_APIs.Models;
using E_Vita_APIs.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Vita_APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LabController : ControllerBase
    {
        private readonly IRepositories<Lab> _repo;

        public LabController(IRepositories<Lab> repo)
        {
            _repo = repo;
        }

        // GET
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var labs = await _repo.GetAllAsync();
            return Ok(labs);
        }

        // GET_BY_ID
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var lab = await _repo.GetByIdAsync(id);
            if (lab == null )
                return NotFound("Lab not found."); 

            return Ok(lab);
        }

        // POST
        [HttpPost]
        public async Task<ActionResult> Create( Lab lab)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _repo.AddAsync(lab);
            return Ok(lab); 
        }

        // PUT
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Lab updatedLab)
        {
            if (id != updatedLab.Id)
                return BadRequest("ID mismatch.");

            try
            {
                await _repo.UpdateAsync(updatedLab, id);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            return Ok("Lab updated successfully.");

        }

        // DELETE
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _repo.DeleteAsync(id);
            return Ok("Lab deleted successfully.");
        }
    }

}
