using E_Vita_APIs.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Vita_APIs.Repositories
{
   
    public class EncounterRepo : IRepositories<Encounter>
    {
        private readonly DBcontext _context;
        public EncounterRepo(DBcontext context)
        {
            _context = context;
        }

        public async Task AddAsync(Encounter entity)
        {
            await _context.Encounters.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var encounter = await _context.Encounters.FindAsync(id);
            if (encounter != null)
            {
                _context.Encounters.Remove(encounter);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Encounter>> GetAllAsync()
        {
            return await _context.Encounters
                .Include(e => e.Patient)
                .Include(e => e.Practitioner)
                .ToListAsync();
        }

        public async Task<Encounter> GetByIdAsync(int id)
        {
            try 
            { 
                return await _context.Encounters
                    .Include(e => e.Patient)
                    .Include(e => e.Practitioner)
                    .FirstOrDefaultAsync(e => e.Id == id); 
            }
            catch
            {
                return new Encounter();
            }
        }

        public async Task UpdateAsync(Encounter updatedEncounter, int id)
        {
            var encounter = await _context.Encounters.FindAsync(id);

            if (encounter == null)
            {
                throw new ArgumentException("Encounter not found");
            }

            encounter.time = updatedEncounter.time;
            encounter.type = updatedEncounter.type;
            encounter.Reason = updatedEncounter.Reason;
            encounter.PatientId = updatedEncounter.PatientId;
            encounter.PractitionerID = updatedEncounter.PractitionerID;

            await _context.SaveChangesAsync();
        }
    }
} 