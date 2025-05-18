using E_Vita_APIs.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Vita_APIs.Repositories
{
    public class PractitionerRepo : IRepositories<Practitioner>
    {
        private readonly DBcontext _context;
        public PractitionerRepo(DBcontext context)
        {
            _context = context;
        }

        public async Task AddAsync(Practitioner entity)
        {
            await _context.Practitioners.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var practitioner = await _context.Practitioners.FindAsync(id);
            if (practitioner != null)
            {
                _context.Practitioners.Remove(practitioner);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Practitioner>> GetAllAsync()
        {
            return await _context.Practitioners
                .Include(p => p.operation_Rooms)
                .Include(p => p.Patients)
                .ToListAsync();
        }

        public async Task<Practitioner> GetByIdAsync(int id)
        {
            try 
            { 
                return await _context.Practitioners
                    .Include(p => p.operation_Rooms)
                    .Include(p => p.Patients)
                    .FirstOrDefaultAsync(p => p.Id == id); 
            }
            catch
            {
                return new Practitioner();
            }
        }

        public async Task UpdateAsync(Practitioner updatedPractitioner, int id)
        {
            var practitioner = await _context.Practitioners.FindAsync(id);

            if (practitioner == null)
            {
                throw new ArgumentException("Practitioner not found");
            }

            practitioner.Name = updatedPractitioner.Name;
            practitioner.Phone = updatedPractitioner.Phone;
            practitioner.Email = updatedPractitioner.Email;
            practitioner.Address = updatedPractitioner.Address;
            practitioner.Gender = updatedPractitioner.Gender;
            practitioner.DateOfBirth = updatedPractitioner.DateOfBirth;

            await _context.SaveChangesAsync();
        }
    }
} 