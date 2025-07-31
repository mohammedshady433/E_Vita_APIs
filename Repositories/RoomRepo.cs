using E_Vita_APIs.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Vita_APIs.Repositories
{
    public class RoomRepo : IRepositories<Rooms>
    {
        private readonly DBcontext _context;
        public RoomRepo(DBcontext context)
        {
            _context = context;
        }

        public async Task AddAsync(Rooms entity)
        {
            await _context.Rooms.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var room = await _context.Rooms.FindAsync(id);
            if (room != null)
            {
                _context.Rooms.Remove(room);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Rooms>> GetAllAsync()
        {
            return await _context.Rooms.ToListAsync();
        }

        public async Task<Rooms> GetByIdAsync(string id)
        {
            try 
            { 
                return await _context.Rooms.FirstOrDefaultAsync(r => r.ID.Equals(id)); 
            }
            catch
            {
                return new Rooms();
            }
        }

        public async Task UpdateAsync(Rooms updatedRoom, string id)
        {
            var room = await _context.Rooms.FindAsync(id);

            if (room == null)
            {
                throw new ArgumentException("Room not found");
            }

            room.availablity = updatedRoom.availablity;
            room.Type = updatedRoom.Type;
            room.Capacity = updatedRoom.Capacity;

            await _context.SaveChangesAsync();
        }
    }
} 