using E_Vita_APIs.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Vita_APIs.Repositories
{
    public class BedRepo : IRepositories<Beds>
    {
        private readonly DBcontext _context;
        public BedRepo(DBcontext context)
        {
            _context = context;
        }

        public async Task AddAsync(Beds entity)
        {
            await _context.Beds.AddAsync(entity);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(string id)
        {
            var bed = await _context.Beds.FindAsync(id);
            if (bed != null)
            {
                _context.Beds.Remove(bed);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<IEnumerable<Beds>> GetAllAsync()
        {
            return await _context.Beds.ToListAsync();
        }

        public async Task<Beds> GetByIdAsync(string id)
        {
            try 
            { 
                return await _context.Beds.FindAsync(id); 
            }
            catch
            {
                return new Beds();
            }
        }
        public async Task UpdateAsync(Beds updatedBed, string id)
        {
            var bed = await _context.Beds.FindAsync(id);

            if (bed == null)
            {
                throw new ArgumentException("Bed not found");
            }

            bed.room = updatedBed.room;
            bed.Active = updatedBed.Active;
            bed.BedType = updatedBed.BedType;
            await _context.SaveChangesAsync();
        }
    }
} 