using E_Vita_APIs.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_Vita_APIs.Repositories
{
    public class FamilyHistoryRepository : IFamilyHistoryRepository
    {
        private readonly DBcontext _context;
        public FamilyHistoryRepository(DBcontext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<FamilyHistory>> GetFamilyHistories()
        {
            return await _context.Set<FamilyHistory>().ToListAsync();
        }
        public async Task<FamilyHistory> GetFamilyHistory(int id)
        {
            return await _context.Set<FamilyHistory>().FindAsync(id);
        }
        public async Task AddFamilyHistory(FamilyHistory familyHistory)
        {
            await _context.Set<FamilyHistory>().AddAsync(familyHistory);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateFamilyHistory(FamilyHistory familyHistory)
        {
            _context.Set<FamilyHistory>().Update(familyHistory);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteFamilyHistory(int id)
        {
            var entity = await _context.Set<FamilyHistory>().FindAsync(id);
            if (entity != null)
            {
                _context.Set<FamilyHistory>().Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
