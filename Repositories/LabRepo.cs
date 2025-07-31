using E_Vita_APIs.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Vita_APIs.Repositories
{
    public class LabRepo : IRepositories<Lab>
    {
        private readonly DBcontext _context;
        public LabRepo(DBcontext context)
        {
            _context = context;
        }

        public async Task AddAsync(Lab entity)
        {
            await _context.Labs.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var lab = await _context.Labs.FindAsync(id);
            if (lab != null)
            {
                _context.Labs.Remove(lab);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Lab>> GetAllAsync()
        {
            return await _context.Labs.ToListAsync();
        }

        public async Task<Lab> GetByIdAsync(string id)
        {
            try 
            { 
                return await _context.Labs.FirstOrDefaultAsync(l => l.ID.Equals(id)); 
            }
            catch
            {
                return new Lab();
            }
        }

        public async Task UpdateAsync(Lab updatedLab, string id)
        {
            var lab = await _context.Labs.FindAsync(id);

            if (lab == null)
            {
                throw new ArgumentException("Lab record not found");
            }

            lab.Status = updatedLab.Status;
            lab.Type = updatedLab.Type;

            await _context.SaveChangesAsync();
        }
    }
}