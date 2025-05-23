using E_Vita_APIs.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Vita_APIs.Repositories
{
    public class PractitionerRoleRepo : IRepositories<Practitioner_Role>
    {
        private readonly DBcontext _context;
        public PractitionerRoleRepo(DBcontext context)
        {
            _context = context;
        }

        public async Task AddAsync(Practitioner_Role entity)
        {
            await _context.Practitioners_Role.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var practitionerRole = await _context.Practitioners_Role.FindAsync(id);
            if (practitionerRole != null)
            {
                _context.Practitioners_Role.Remove(practitionerRole);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Practitioner_Role>> GetAllAsync()
        {
            return await _context.Practitioners_Role
                .Include(p => p.Practitioner)
                .ToListAsync();
        }

        public async Task<Practitioner_Role> GetByIdAsync(int id)
        {
            try 
            { 
                return await _context.Practitioners_Role
                    .Include(p => p.Practitioner)
                    .FirstOrDefaultAsync(p => p.PractitionerId == id); 
            }
            catch
            {
                return new Practitioner_Role();
            }
        }

        public async Task UpdateAsync(Practitioner_Role updatedPractitionerRole, int id)
        {
            var practitionerRole = await _context.Practitioners_Role.FindAsync(id);

            if (practitionerRole == null)
            {
                throw new ArgumentException("Practitioner role record not found");
            }

            practitionerRole.StartTime = updatedPractitionerRole.StartTime;
            practitionerRole.EndTime = updatedPractitionerRole.EndTime;
            practitionerRole.Code = updatedPractitionerRole.Code;
            practitionerRole.Specialty = updatedPractitionerRole.Specialty;
            practitionerRole.Service = updatedPractitionerRole.Service;
            practitionerRole.DayOfWeek = updatedPractitionerRole.DayOfWeek;
            practitionerRole.PractitionerId = updatedPractitionerRole.PractitionerId;

            await _context.SaveChangesAsync();
        }
    }
} 