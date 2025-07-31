using E_Vita_APIs.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Vita_APIs.Repositories
{
    public class AccountantRepo : IRepositories<Accountant>
    {
        private readonly DBcontext _context;
        public AccountantRepo(DBcontext context)
        {
            _context = context;
        }

        public async Task AddAsync(Accountant entity)
        {
            await _context.Accountants.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var accountant = await _context.Accountants.FindAsync(id);
            if (accountant != null)
            {
                _context.Accountants.Remove(accountant);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Accountant>> GetAllAsync()
        {
            return await _context.Accountants
                .Include(a => a.finance)
                .ToListAsync();
        }

        public async Task<Accountant> GetByIdAsync(string id)
        {
            try 
            {
                return await _context.Accountants.FindAsync(id);
            }
            catch
            {
                return new Accountant();
            }
        }

        public async Task UpdateAsync(Accountant updatedAccountant, string id)
        {
            var accountant = await _context.Accountants.FindAsync(id);

            if (accountant == null)
            {
                throw new ArgumentException("Accountant not found");
            }

            accountant.Salary = updatedAccountant.Salary;
            accountant.Rank = updatedAccountant.Rank;
            accountant.Finance_ID = updatedAccountant.Finance_ID;
            accountant.Address = updatedAccountant.Address;

            await _context.SaveChangesAsync();
        }
    }
} 