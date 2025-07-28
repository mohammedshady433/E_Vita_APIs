using E_Vita_APIs.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Vita_APIs.Repositories
{
    public class MedicationRepo : IRepositories<Medication>
    {
        private readonly DBcontext _context;
        public MedicationRepo(DBcontext context)
        {
            _context = context;
        }

        public async Task AddAsync(Medication entity)
        {
            await _context.Medications.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var medication = await _context.Medications.FindAsync(id);
            if (medication != null)
            {
                _context.Medications.Remove(medication);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Medication>> GetAllAsync()
        {
            return await _context.Medications
                .Include(m => m.Patient)
                .ToListAsync();
        }

        public async Task<Medication> GetByIdAsync(string id)
        {
            try 
            { 
                return await _context.Medications
                    .Include(m => m.Patient)
                    .FirstOrDefaultAsync(m => m.Id.Equals(id) );
            }
            catch
            {
                return new Medication();
            }
        }

        public async Task UpdateAsync(Medication updatedMedication, string id)
        {
            var medication = await _context.Medications.FindAsync(id);

            if (medication == null)
            {
                throw new ArgumentException("Medication record not found");
            }

            medication.Name = updatedMedication.Name;
            medication.Dosage = updatedMedication.Dosage;
            medication.Active_site = updatedMedication.Active_site;
            medication.Date = updatedMedication.Date;
            medication.PatientId = updatedMedication.PatientId;

            await _context.SaveChangesAsync();
        }
    }
} 