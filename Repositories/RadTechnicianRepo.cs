using E_Vita_APIs.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Vita_APIs.Repositories
{
    public class RadTechnicianRepo : IRepositories<Rad_technician>
    {
        private readonly DBcontext _context;
        public RadTechnicianRepo(DBcontext context)
        {
            _context = context;
        }

        public async Task AddAsync(Rad_technician entity)
        {
            await _context.Rad_Technicians.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var radTechnician = await _context.Rad_Technicians.FindAsync(id);
            if (radTechnician != null)
            {
                _context.Rad_Technicians.Remove(radTechnician);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Rad_technician>> GetAllAsync()
        {
            return await _context.Rad_Technicians
                .ToListAsync();
        }

        public async Task<Rad_technician> GetByIdAsync(string id)
        {
            try 
            { 
                return await _context.Rad_Technicians
                    .FirstOrDefaultAsync(rt => rt.Rad_Tech_ID.Equals(id)); 
            }
            catch
            {
                return new Rad_technician();
            }
        }

        public async Task UpdateAsync(Rad_technician updatedRadTechnician, string id)
        {
            var radTechnician = await _context.Rad_Technicians.FindAsync(id);

            if (radTechnician == null)
            {
                throw new ArgumentException("Rad Technician not found");
            }

            radTechnician.Salary = updatedRadTechnician.Salary;
            radTechnician.Shift = updatedRadTechnician.Shift;

            await _context.SaveChangesAsync();
        }
    }
} 