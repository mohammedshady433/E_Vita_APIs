using E_Vita_APIs.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Vita_APIs.Repositories
{
    public class AssignedRepo : IRepositories<Assigned>
    {
        private readonly DBcontext _context;
        public AssignedRepo(DBcontext context)
        {
            _context = context;
        }
        public async Task AddAsync(Assigned entity)
        {
            await _context.Assigneds.AddAsync(entity);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(string id)
        {
            var assigned = await _context.Assigneds.FindAsync(id);
            if (assigned != null)
            {
                _context.Assigneds.Remove(assigned);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<IEnumerable<Assigned>> GetAllAsync()
        {
            return await _context.Assigneds
                .Include(a => a.Rooms)
                .Include(a => a.User)
                .ToListAsync();
        }
        public async Task<Assigned> GetByIdAsync(string id)
        {
            try
            {
                return await _context.Assigneds
                    .Include(a => a.Rooms)
                    .Include(a => a.User)
                    .FirstOrDefaultAsync(a => a.RoomID.Equals(id) || a.NurseID.Equals(id));
            }
            catch
            {
                return new Assigned();
            }
        }
        public async Task UpdateAsync(Assigned updatedAssigned, string id)
        {
            var assigned = await _context.Assigneds.FindAsync(id);

            if (assigned == null)
            {
                throw new ArgumentException("Assigned entity not found");
            }

            assigned.RoomID = updatedAssigned.RoomID;
            assigned.NurseID = updatedAssigned.NurseID;
            assigned.Rooms = updatedAssigned.Rooms;
            assigned.User = updatedAssigned.User;

            await _context.SaveChangesAsync();
        }
    }
}