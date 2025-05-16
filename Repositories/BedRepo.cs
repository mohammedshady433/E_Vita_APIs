using E_Vita_APIs.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Vita_APIs.Repositories
{
    public class BedRepo : IRepositories<Bed>
    {
        private readonly DBcontext _context;
        public BedRepo(DBcontext context)
        {
            _context = context;
        }

        public async Task AddAsync(Bed entity)
        {
            await _context.Beds.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var bed = await _context.Beds.FindAsync(id);
            if (bed != null)
            {
                _context.Beds.Remove(bed);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Bed>> GetAllAsync()
        {
            return await _context.Beds.ToListAsync();
        }

        public async Task<Bed> GetByIdAsync(int id)
        {
            try 
            { 
                return await _context.Beds.FindAsync(id); 
            }
            catch
            {
                return new Bed();
            }
        }

        public async Task UpdateAsync(Bed updatedBed, int id)
        {
            var bed = await _context.Beds.FindAsync(id);

            if (bed == null)
            {
                throw new ArgumentException("Bed not found");
            }

            bed.number = updatedBed.number;
            bed.Active = updatedBed.Active;

            await _context.SaveChangesAsync();
        }
    }
} 