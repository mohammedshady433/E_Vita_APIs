﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using E_Vita_APIs.Models;
using E_Vita_APIs.Repositories;

namespace E_Vita_APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRepositories<Rooms> _roomRepo;
        public RoomController(IRepositories<Rooms> roomRepo)
        {
            _roomRepo = roomRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var rooms = await _roomRepo.GetAllAsync();
            return Ok(rooms);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var room = await _roomRepo.GetByIdAsync(id);
            if (room == null)
            {
                return NotFound();
            }
            return Ok(room);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Rooms room)
        {
            if (room == null)
            {
                return BadRequest("Invalid room data.");
            }
            await _roomRepo.AddAsync(room);
            return Ok();
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var room = await _roomRepo.GetByIdAsync(id);
            if (room == null)
            {
                return NotFound();
            }
            await _roomRepo.DeleteAsync(id);
            return Ok();
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] Rooms updatedRoom)
        {
            if (updatedRoom == null)
            {
                return BadRequest("Invalid room data.");
            }
            var room = await _roomRepo.GetByIdAsync(id);
            if (room == null)
            {
                return NotFound();
            }
            await _roomRepo.UpdateAsync(updatedRoom, id);
            return Ok();
        }
    }
}
