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

        public async Task DeleteAsync(int id)
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
                .Include(m => m.Practitioner)
                .ToListAsync();
        }

        public async Task<Medication> GetByIdAsync(int id)
        {
            try 
            { 
                return await _context.Medications
                    .Include(m => m.Patient)
                    .Include(m => m.Practitioner)
                    .FirstOrDefaultAsync(m => m.Id == id);
            }
            catch
            {
                return new Medication();
            }
        }

        public async Task UpdateAsync(Medication updatedMedication, int id)
        {
            var medication = await _context.Medications.FindAsync(id);

            if (medication == null)
            {
                throw new ArgumentException("Medication record not found");
            }

            medication.Dose = updatedMedication.Dose;
            medication.Time = updatedMedication.Time;
            medication.Medication_name = updatedMedication.Medication_name;
            medication.PractitionerID = updatedMedication.PractitionerID;
            medication.PatientId = updatedMedication.PatientId;

            await _context.SaveChangesAsync();
        }
    }
} 