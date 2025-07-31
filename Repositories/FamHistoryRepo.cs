using E_Vita_APIs.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Vita_APIs.Repositories
{
    public class FamHistoryRepo : IRepositories<FamilyHistory>
    {
        private readonly DBcontext _context;
        public FamHistoryRepo(DBcontext context)
        {
            _context = context;
        }

        public async Task AddAsync(FamilyHistory entity)
        {
            await _context.FamilyHistories.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var famHistory = await _context.FamilyHistories.FindAsync(id);
            if (famHistory != null)
            {
                _context.FamilyHistories.Remove(famHistory);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<FamilyHistory>> GetAllAsync()
        {
            return await _context.FamilyHistories.ToListAsync();
        }

        public async Task<FamilyHistory> GetByIdAsync(string id)
        {
            try 
            { 
                return await _context.FamilyHistories.FirstOrDefaultAsync(f => f.Fam_ID.Equals(id)); 
            }
            catch
            {
                return new FamilyHistory();
            }
        }

        public async Task UpdateAsync(FamilyHistory updatedFamHistory, string id)
        {
            var famHistory = await _context.FamilyHistories.FindAsync(id);

            if (famHistory == null)
            {
                throw new ArgumentException("Family history record not found");
            }

            famHistory.Explanation = updatedFamHistory.Explanation;
            famHistory.Relation = updatedFamHistory.Relation;
            await _context.SaveChangesAsync();
        }
    }
} 