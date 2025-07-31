using E_Vita_APIs.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Vita_APIs.Repositories
{
    public class LabTechnicianRepo : IRepositories<Lab_technician>
    {
        private readonly DBcontext _context;
        public LabTechnicianRepo(DBcontext context)
        {
            _context = context;
        }

        public async Task AddAsync(Lab_technician entity)
        {
            await _context.Lab_Technicians.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var labTechnician = await _context.Lab_Technicians.FindAsync(id);
            if (labTechnician != null)
            {
                _context.Lab_Technicians.Remove(labTechnician);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Lab_technician>> GetAllAsync()
        {
            return await _context.Lab_Technicians
                .ToListAsync();
        }

        public async Task<Lab_technician> GetByIdAsync(string id)
        {
            try 
            { 
                return await _context.Lab_Technicians
                    .FirstOrDefaultAsync(lt => lt.ID.Equals(id)); 
            }
            catch
            {
                return new Lab_technician();
            }
        }

        public async Task UpdateAsync(Lab_technician updatedLabTechnician, string id)
        {
            var labTechnician = await _context.Lab_Technicians.FindAsync(id);

            if (labTechnician == null)
            {
                throw new ArgumentException("Lab Technician not found");
            }

            labTechnician.Salary = updatedLabTechnician.Salary;
            labTechnician.Department = updatedLabTechnician.Department;

            await _context.SaveChangesAsync();
        }
    }
} 