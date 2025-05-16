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

        public async Task DeleteAsync(int id)
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
            return await _context.Labs
                .Include(l => l.Results)
                .ToListAsync();
        }

        public async Task<Lab> GetByIdAsync(int id)
        {
            try 
            { 
                return await _context.Labs
                    .Include(l => l.Results)
                    .FirstOrDefaultAsync(l => l.Id == id); 
            }
            catch
            {
                return new Lab();
            }
        }

        public async Task UpdateAsync(Lab updatedLab, int id)
        {
            var lab = await _context.Labs.FindAsync(id);

            if (lab == null)
            {
                throw new ArgumentException("Lab record not found");
            }

            lab.Photo = updatedLab.Photo;
            lab.Note = updatedLab.Note;
            lab.LabType = updatedLab.LabType;

            await _context.SaveChangesAsync();
        }
    }
} 