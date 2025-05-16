using E_Vita_APIs.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Vita_APIs.Repositories
{
    public class DischargeRepo : IRepositories<Discharge>
    {
        private readonly DBcontext _context;
        public DischargeRepo(DBcontext context)
        {
            _context = context;
        }

        public async Task AddAsync(Discharge entity)
        {
            await _context.Discharges.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var discharge = await _context.Discharges.FindAsync(id);
            if (discharge != null)
            {
                _context.Discharges.Remove(discharge);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Discharge>> GetAllAsync()
        {
            return await _context.Discharges
                .Include(d => d.Patient)
                .ToListAsync();
        }

        public async Task<Discharge> GetByIdAsync(int id)
        {
            try 
            { 
                return await _context.Discharges
                    .Include(d => d.Patient)
                    .FirstOrDefaultAsync(d => d.PatientId == id); 
            }
            catch
            {
                return new Discharge();
            }
        }

        public async Task UpdateAsync(Discharge updatedDischarge, int id)
        {
            var discharge = await _context.Discharges.FindAsync(id);

            if (discharge == null)
            {
                throw new ArgumentException("Discharge record not found");
            }

            discharge.Date = updatedDischarge.Date;
            discharge.When = updatedDischarge.When;
            discharge.Note = updatedDischarge.Note;
            discharge.DischargeType = updatedDischarge.DischargeType;
            discharge.PatientId = updatedDischarge.PatientId;

            await _context.SaveChangesAsync();
        }
    }
} 