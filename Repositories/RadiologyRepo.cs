using E_Vita_APIs.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Vita_APIs.Repositories
{
    public class RadiologyRepo : IRepositories<Radiology>
    {
        private readonly DBcontext _context;
        public RadiologyRepo(DBcontext context)
        {
            _context = context;
        }

        public async Task AddAsync(Radiology entity)
        {
            await _context.Radiologies.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var radiology = await _context.Radiologies.FindAsync(id);
            if (radiology != null)
            {
                _context.Radiologies.Remove(radiology);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Radiology>> GetAllAsync()
        {
            return await _context.Radiologies
                .Include(r => r.Prescriptions)
                .ToListAsync();
        }

        public async Task<Radiology> GetByIdAsync(string id)
        {
            try 
            { 
                return await _context.Radiologies
                    .Include(r => r.Prescriptions)
                    .FirstOrDefaultAsync(r => r.Id == id); 
            }
            catch
            {
                return new Radiology();
            }
        }

        public async Task UpdateAsync(Radiology updatedRadiology, string id)
        {
            var radiology = await _context.Radiologies.FindAsync(id);

            if (radiology == null)
            {
                throw new ArgumentException("Radiology record not found");
            }

            radiology.Date = updatedRadiology.Date;
            radiology.Status = updatedRadiology.Status;
            radiology.Examination_Type = updatedRadiology.Examination_Type;

            await _context.SaveChangesAsync();
        }
    }
} 