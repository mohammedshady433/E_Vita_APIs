using E_Vita_APIs.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Vita_APIs.Repositories
{
    public class PatientHistoryRepo : IRepositories<PatientHistory>
    {
        private readonly DBcontext _context;
        public PatientHistoryRepo(DBcontext context)
        {
            _context = context;
        }

        public async Task AddAsync(PatientHistory entity)
        {
            await _context.patientHistories.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var history = await _context.patientHistories.FindAsync(id);
            if (history != null)
            {
                _context.patientHistories.Remove(history);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<PatientHistory>> GetAllAsync()
        {
            return await _context.patientHistories
                .Include(h => h.patient)
                .ToListAsync();
        }

        public async Task<PatientHistory> GetByIdAsync(string id)
        {
            try
            {
                return await _context.patientHistories
                    .Include(h => h.patient)
                    .FirstOrDefaultAsync(h => h.ID.Equals(id));
            }
            catch
            {
                return new PatientHistory();
            }
        }

        public async Task UpdateAsync(PatientHistory updatedHistory, string id)
        {
            var history = await _context.patientHistories.FindAsync(id);

            if (history == null)
            {
                throw new ArgumentException("PatientHistory not found");
            }

            history.Disease = updatedHistory.Disease;
            history.surgery = updatedHistory.surgery;
            history.PatientId = updatedHistory.PatientId;
            history.patient = updatedHistory.patient;

            await _context.SaveChangesAsync();
        }
    }
}