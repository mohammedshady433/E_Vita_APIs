using E_Vita_APIs.Models;
using Microsoft.EntityFrameworkCore;
namespace E_Vita_APIs.Repositories
{
    
        public class DaysRepo : IRepositories<Days>
        {
            private readonly DBcontext _context;

            public DaysRepo(DBcontext context)
            {
                _context = context;
            }

            public async Task AddAsync(Days entity)
            {
                await _context.Days.AddAsync(entity);
                await _context.SaveChangesAsync();
            }

            public async Task DeleteAsync(string id)
            {
                var day = await _context.Days.FindAsync(id);
                if (day != null)
                {
                    _context.Days.Remove(day);
                    await _context.SaveChangesAsync();
                }
            }

            public async Task<IEnumerable<Days>> GetAllAsync()
            {
                return await _context.Days
                    .Include(d => d.Schedules)
                    .ToListAsync();
            }

            public async Task<Days> GetByIdAsync(string id)
            {
                try
                {
                    return await _context.Days
                        .Include(d => d.Schedules)
                        .FirstOrDefaultAsync(d => d.Days_ID.Equals(id));
                }
                catch
                {
                    return new Days();
                }
            }

            public async Task UpdateAsync(Days updatedDay, string id)
            {
                var day = await _context.Days.FindAsync(id);

                if (day == null)
                {
                    throw new ArgumentException("Day not found");
                }

                day.DayName = updatedDay.DayName;
                day.Days_ID = updatedDay.Days_ID;
                await _context.SaveChangesAsync();
            }
        }
    }


