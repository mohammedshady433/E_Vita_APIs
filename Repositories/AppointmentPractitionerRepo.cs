using E_Vita_APIs.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_Vita_APIs.Repositories
{
    public class AppointmentPractitionerRepo : IRepositories<AppointmentPractitioner>
    {
        private readonly DBcontext _context;
        public AppointmentPractitionerRepo(DBcontext context)
        {
            _context = context;
        }

        public async Task AddAsync(AppointmentPractitioner entity)
        {
            await _context.Set<AppointmentPractitioner>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int appointmentId, int practitionerId)
        {
            var entity = await _context.Set<AppointmentPractitioner>()
                .FirstOrDefaultAsync(ap => ap.AppointmentId == appointmentId && ap.PractitionersId == practitionerId);
            if (entity != null)
            {
                _context.Set<AppointmentPractitioner>().Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        // Overload for IRepositories interface compatibility (if needed)
        public async Task DeleteAsync(int id)
        {
            // Not applicable for composite key, so do nothing or throw
            throw new NotSupportedException("Use DeleteAsync(int appointmentId, int practitionerId) for composite key.");
        }

        public async Task<IEnumerable<AppointmentPractitioner>> GetAllAsync()
        {
            return await _context.Set<AppointmentPractitioner>()
                .Include(ap => ap.Appointment)
                .Include(ap => ap.Practitioner)
                .ToListAsync();
        }

        // Change the parameter name from float to int
        public async Task<AppointmentPractitioner> GetByIdAsync(int id)
        {
            // Not applicable for composite key entities, returning first match or null
            return await _context.Set<AppointmentPractitioner>()
                .Include(ap => ap.Appointment)
                .Include(ap => ap.Practitioner)
                .FirstOrDefaultAsync(ap => ap.PractitionersId == id);
        }

        // Keep your original method with a different name
        public async Task<IEnumerable<AppointmentPractitioner>> GetByPractitionerIdAsync(int practitionerId)
        {
            return await _context.Set<AppointmentPractitioner>()
                .Include(ap => ap.Appointment)
                .Include(ap => ap.Practitioner)
                .Where(ap => ap.PractitionersId == practitionerId)
                .ToListAsync();
        }


        public async Task UpdateAsync(AppointmentPractitioner updatedEntity, int appointmentId, int practitionerId)
        {
            var entity = await _context.Set<AppointmentPractitioner>()
                .FirstOrDefaultAsync(ap => ap.AppointmentId == appointmentId && ap.PractitionersId == practitionerId);

            if (entity == null)
                throw new ArgumentException("AppointmentPractitioner not found");

            entity.AppointmentId = updatedEntity.AppointmentId;
            entity.PractitionersId = updatedEntity.PractitionersId;
            entity.Appointment = updatedEntity.Appointment;
            entity.Practitioner = updatedEntity.Practitioner;

            await _context.SaveChangesAsync();
        }

        // Overload for IRepositories interface compatibility (if needed)
        public async Task UpdateAsync(AppointmentPractitioner entity, int id)
        {
            throw new NotSupportedException("Use UpdateAsync(entity, appointmentId, practitionerId) for composite key.");
        }
    }
}
