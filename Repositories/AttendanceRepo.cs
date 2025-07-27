using E_Vita_APIs.Models;
using Microsoft.EntityFrameworkCore;
namespace E_Vita_APIs.Repositories
{
    
        public class AttendanceRepo : IRepositories<Attendance>
        {
            private readonly DBcontext _context;

            public AttendanceRepo(DBcontext context)
            {
                _context = context;
            }

            public async Task AddAsync(Attendance entity)
            {
                await _context.Attendances.AddAsync(entity);
                await _context.SaveChangesAsync();
            }

            public async Task DeleteAsync(int id)
            {
                var attendance = await _context.Attendances.FindAsync(id);
                if (attendance != null)
                {
                    _context.Attendances.Remove(attendance);
                    await _context.SaveChangesAsync();
                }
            }

            public async Task<IEnumerable<Attendance>> GetAllAsync()
            {
                return await _context.Attendances
                    .Include(a => a.User)
                    .ToListAsync();
            }

            public async Task<Attendance> GetByIdAsync(int id)
            {
                try
                {
                    return await _context.Attendances
                        .Include(a => a.User)
                        .FirstOrDefaultAsync(a => a.ID == id);
                }
                catch
                {
                    return new Attendance();
                }
            }

            public async Task UpdateAsync(Attendance updatedAttendance, int id)
            {
                var attendance = await _context.Attendances.FindAsync(id);

                if (attendance == null)
                    throw new ArgumentException("Attendance record not found");

                attendance.Attend_Time = updatedAttendance.Attend_Time;
                attendance.Leave_Time = updatedAttendance.Leave_Time;
                attendance.Date = updatedAttendance.Date;
                attendance.UserID = updatedAttendance.UserID;

                await _context.SaveChangesAsync();
            }
        }
    }



