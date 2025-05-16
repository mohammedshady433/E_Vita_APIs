using E_Vita_APIs.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Vita_APIs.Repositories
{
    public class OperationRoomRepo : IRepositories<Operation_Room>
    {
        private readonly DBcontext _context;
        public OperationRoomRepo(DBcontext context)
        {
            _context = context;
        }

        public async Task AddAsync(Operation_Room entity)
        {
            await _context.Operation_Rooms.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var operationRoom = await _context.Operation_Rooms.FindAsync(id);
            if (operationRoom != null)
            {
                _context.Operation_Rooms.Remove(operationRoom);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Operation_Room>> GetAllAsync()
        {
            return await _context.Operation_Rooms
                .Include(o => o.Practitioners)
                .Include(o => o.Room)
                .ToListAsync();
        }

        public async Task<Operation_Room> GetByIdAsync(int id)
        {
            try 
            { 
                return await _context.Operation_Rooms
                    .Include(o => o.Practitioners)
                    .Include(o => o.Room)
                    .FirstOrDefaultAsync(o => o.RoomId == id); 
            }
            catch
            {
                return new Operation_Room();
            }
        }

        public async Task UpdateAsync(Operation_Room updatedOperationRoom, int id)
        {
            var operationRoom = await _context.Operation_Rooms.FindAsync(id);

            if (operationRoom == null)
            {
                throw new ArgumentException("Operation room record not found");
            }

            operationRoom.RoomStatus = updatedOperationRoom.RoomStatus;
            operationRoom.Operation = updatedOperationRoom.Operation;
            operationRoom.Equipment = updatedOperationRoom.Equipment;
            operationRoom.RoomId = updatedOperationRoom.RoomId;

            await _context.SaveChangesAsync();
        }
    }
} 