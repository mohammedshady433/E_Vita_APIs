using E_Vita_APIs.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Vita_APIs.Repositories
{
    public class RoomRepo : IRepositories<Room>
    {
        private readonly DBcontext _context;
        public RoomRepo(DBcontext context)
        {
            _context = context;
        }

        public async Task AddAsync(Room entity)
        {
            await _context.Rooms.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var room = await _context.Rooms.FindAsync(id);
            if (room != null)
            {
                _context.Rooms.Remove(room);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Room>> GetAllAsync()
        {
            return await _context.Rooms
                .Include(r => r.Patient)
                .Include(r => r.BedID)
                .ToListAsync();
        }

        public async Task<Room> GetByIdAsync(int id)
        {
            try 
            { 
                return await _context.Rooms
                    .Include(r => r.Patient)
                    .Include(r => r.BedID)
                    .FirstOrDefaultAsync(r => r.ID == id); 
            }
            catch
            {
                return new Room();
            }
        }

        public async Task UpdateAsync(Room updatedRoom, int id)
        {
            var room = await _context.Rooms.FindAsync(id);

            if (room == null)
            {
                throw new ArgumentException("Room not found");
            }

            room.availablity = updatedRoom.availablity;
            room.Floor = updatedRoom.Floor;
            room.Name = updatedRoom.Name;
            room.PatientId = updatedRoom.PatientId;
            room.BedId = updatedRoom.BedId;

            await _context.SaveChangesAsync();
        }
    }
} 