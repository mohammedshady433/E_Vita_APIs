using E_Vita_APIs.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Vita_APIs.Repositories
{
    public class FinancialRepo : IRepositories<Financial>
    {
        private readonly DBcontext _context;
        public FinancialRepo(DBcontext context)
        {
            _context = context;
        }

        public async Task AddAsync(Financial entity)
        {
            await _context.Financials.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var financial = await _context.Financials.FindAsync(id);
            if (financial != null)
            {
                _context.Financials.Remove(financial);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Financial>> GetAllAsync()
        {
            return await _context.Financials
                .Include(f => f.Patient)
                .ToListAsync();
        }

        public async Task<Financial> GetByIdAsync(int id)
        {
            try 
            { 
                return await _context.Financials
                    .Include(f => f.Patient)
                    .FirstOrDefaultAsync(f => f.Id == id); 
            }
            catch
            {
                return new Financial();
            }
        }

        public async Task UpdateAsync(Financial updatedFinancial, int id)
        {
            var financial = await _context.Financials.FindAsync(id);

            if (financial == null)
            {
                throw new ArgumentException("Financial record not found");
            }

            financial.Status = updatedFinancial.Status;
            financial.Amount = updatedFinancial.Amount;
            financial.Paid_Amount = updatedFinancial.Paid_Amount;
            financial.Method = updatedFinancial.Method;
            financial.PatientId = updatedFinancial.PatientId;
            financial.Payment_Date = updatedFinancial.Payment_Date;

            await _context.SaveChangesAsync();
        }
    }
} 