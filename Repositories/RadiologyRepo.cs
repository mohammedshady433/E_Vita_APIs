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

        public async Task DeleteAsync(int id)
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
                .Include(r => r.Patient)
                .ToListAsync();
        }

        public async Task<Radiology> GetByIdAsync(int id)
        {
            try 
            { 
                return await _context.Radiologies
                    .Include(r => r.Patient)
                    .FirstOrDefaultAsync(r => r.Id == id); 
            }
            catch
            {
                return new Radiology();
            }
        }

        public async Task UpdateAsync(Radiology updatedRadiology, int id)
        {
            var radiology = await _context.Radiologies.FindAsync(id);

            if (radiology == null)
            {
                throw new ArgumentException("Radiology record not found");
            }

            radiology.Date = updatedRadiology.Date;
            radiology.Photo = updatedRadiology.Photo;
            radiology.Note = updatedRadiology.Note;
            radiology.PatientId = updatedRadiology.PatientId;

            await _context.SaveChangesAsync();
        }
    }
} 