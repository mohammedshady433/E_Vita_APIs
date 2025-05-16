using E_Vita_APIs.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Vita_APIs.Repositories
{
    public class FamHistoryRepo : IRepositories<FamHistory>
    {
        private readonly DBcontext _context;
        public FamHistoryRepo(DBcontext context)
        {
            _context = context;
        }

        public async Task AddAsync(FamHistory entity)
        {
            await _context.FamHistories.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var famHistory = await _context.FamHistories.FindAsync(id);
            if (famHistory != null)
            {
                _context.FamHistories.Remove(famHistory);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<FamHistory>> GetAllAsync()
        {
            return await _context.FamHistories
                .Include(f => f.Patient)
                .Include(f => f.Practitioner)
                .ToListAsync();
        }

        public async Task<FamHistory> GetByIdAsync(int id)
        {
            try 
            { 
                return await _context.FamHistories
                    .Include(f => f.Patient)
                    .Include(f => f.Practitioner)
                    .FirstOrDefaultAsync(f => f.ID == id); 
            }
            catch
            {
                return new FamHistory();
            }
        }

        public async Task UpdateAsync(FamHistory updatedFamHistory, int id)
        {
            var famHistory = await _context.FamHistories.FindAsync(id);

            if (famHistory == null)
            {
                throw new ArgumentException("Family history record not found");
            }

            famHistory.Disease = updatedFamHistory.Disease;
            famHistory.Date = updatedFamHistory.Date;
            famHistory.PractitionerID = updatedFamHistory.PractitionerID;
            famHistory.PatientId = updatedFamHistory.PatientId;

            await _context.SaveChangesAsync();
        }
    }
} 