using E_Vita_APIs.Models;
using Microsoft.EntityFrameworkCore;
namespace E_Vita_APIs.Repositories
{
   
        public class FinanceRepo : IRepositories<Finance>
        {
            private readonly DBcontext _context;

            public FinanceRepo(DBcontext context)
            {
                _context = context;
            }

            public async Task AddAsync(Finance entity)
            {
                await _context.Finances.AddAsync(entity);
                await _context.SaveChangesAsync();
            }

            public async Task DeleteAsync(string id)
            {
                var finance = await _context.Finances.FindAsync(id);
                if (finance != null)
                {
                    _context.Finances.Remove(finance);
                    await _context.SaveChangesAsync();
                }
            }

            public async Task<IEnumerable<Finance>> GetAllAsync()
            {
                return await _context.Finances
                    .Include(f => f.Patients)
                    .Include(f => f.Accountants)
                    .ToListAsync();
            }

            public async Task<Finance> GetByIdAsync(string id)
            {
                try
                {
                    return await _context.Finances
                        .Include(f => f.Patients)
                        .Include(f => f.Accountants)
                        .FirstOrDefaultAsync(f => f.Finance_ID.Equals(id));
                }
                catch
                {
                    return new Finance();
                }
            }

            public async Task UpdateAsync(Finance updatedFinance, string id)
            {
                var finance = await _context.Finances.FindAsync(id);

                if (finance == null)
                    throw new ArgumentException("Finance record not found");

                finance.Salaries = updatedFinance.Salaries;
                finance.Appointment_Income = updatedFinance.Appointment_Income;
                finance.RoomReservation_Income = updatedFinance.RoomReservation_Income;
                finance.Appointment_Outcome = updatedFinance.Appointment_Outcome;
                finance.RoomReservation_Outcome = updatedFinance.RoomReservation_Outcome;

                await _context.SaveChangesAsync();
            }
        }
    }


