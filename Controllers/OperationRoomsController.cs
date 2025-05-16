using E_Vita_APIs.Models;
using E_Vita_APIs.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Vita_APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationRoomsController : ControllerBase
    {
        private readonly IRepositories<Operation_Room> _repo;

        public OperationRoomsController(IRepositories<Operation_Room> repo)
        {
            _repo = repo;
        }

        // GET
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var rooms = await _repo.GetAllAsync();
            return Ok(rooms);
        }

        // GET
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var room = await _repo.GetByIdAsync(id);
            if (room == null )
                return NotFound("Operation room not found.");

            return Ok(room);
        }

        // POST
        [HttpPost]
        public async Task<ActionResult> Create( Operation_Room operationRoom)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _repo.AddAsync(operationRoom);
            return Ok(operationRoom); 
        }

        // PUT
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Operation_Room updatedRoom)
        {
            if (id != updatedRoom.RoomId)
                return BadRequest("ID mismatch.");

            try
            {
                await _repo.UpdateAsync(updatedRoom, id);
                return Ok("Operation room updated successfully.");
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message); 
            }
        }

        // DELETE
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _repo.DeleteAsync(id);
            return Ok("Operation room deleted successfully.");
        }
    }
}
