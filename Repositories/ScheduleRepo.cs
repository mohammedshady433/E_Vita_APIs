using E_Vita_APIs.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Vita_APIs.Repositories
{
    public class ScheduleRepo : IRepositories<Scheduale>
    {
        private readonly DBcontext _context;
        public ScheduleRepo(DBcontext context)
        {
            _context = context;
        }

        public async Task AddAsync(Scheduale entity)
        {
            await _context.scheduales.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var schedule = await _context.scheduales.FindAsync(id);
            if (schedule != null)
            {
                _context.scheduales.Remove(schedule);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Scheduale>> GetAllAsync()
        {
            return await _context.scheduales
                .Include(s => s.Appointment)
                .ToListAsync();
        }

        public async Task<Scheduale> GetByIdAsync(int id)
        {
            try 
            { 
                return await _context.scheduales
                    .Include(s => s.Appointment)
                    .FirstOrDefaultAsync(s => s.Id == id); 
            }
            catch
            {
                return new Scheduale();
            }
        }

        public async Task UpdateAsync(Scheduale updatedSchedule, int id)
        {
            var schedule = await _context.scheduales.FindAsync(id);

            if (schedule == null)
            {
                throw new ArgumentException("Schedule not found");
            }

            schedule.Active = updatedSchedule.Active;
            schedule.Service_Type = updatedSchedule.Service_Type;
            schedule.speciality = updatedSchedule.speciality;
            schedule.AppointmentId = updatedSchedule.AppointmentId;

            await _context.SaveChangesAsync();
        }
    }
} 