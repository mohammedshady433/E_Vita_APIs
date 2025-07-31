using E_Vita_APIs.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Vita_APIs.Repositories
{
    public class ScheduleRepo : IRepositories<Schedule>
    {
        private readonly DBcontext _context;
        public ScheduleRepo(DBcontext context)
        {
            _context = context;
        }

        public async Task AddAsync(Schedule entity)
        {
            await _context.scheduales.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var schedule = await _context.scheduales.FindAsync(id);
            if (schedule != null)
            {
                _context.scheduales.Remove(schedule);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Schedule>> GetAllAsync()
        {
            return await _context.scheduales.ToListAsync();
        }

        public async Task<Schedule> GetByIdAsync(string id)
        {
            try 
            { 
                return await _context.scheduales.FirstOrDefaultAsync(s => s.Id == id); 
            }
            catch
            {
                return new Schedule();
            }
        }

        public async Task UpdateAsync(Schedule updatedSchedule, string id)
        {
            var schedule = await _context.scheduales.FindAsync(id);

            if (schedule == null)
            {
                throw new ArgumentException("Schedule not found");
            }

            schedule.StartTime = updatedSchedule.StartTime;
            schedule.EndTime = updatedSchedule.EndTime;
            schedule.User_Id = updatedSchedule.User_Id;
            schedule.Days_ID = updatedSchedule.Days_ID;

            await _context.SaveChangesAsync();
        }
    }
} 