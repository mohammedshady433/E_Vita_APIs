using E_Vita_APIs.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Vita_APIs.Repositories
{
    public class PrescriptionRepo : IRepositories<Prescription>
    {
        private readonly DBcontext _context;
        public PrescriptionRepo(DBcontext context)
        {
            _context = context;
        }

        public async Task AddAsync(Prescription entity)
        {
            await _context.Prescriptions.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var prescription = await _context.Prescriptions.FindAsync(id);
            if (prescription != null)
            {
                _context.Prescriptions.Remove(prescription);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Prescription>> GetAllAsync()
        {
            return await _context.Prescriptions
                .Include(p => p.Patient)
                .Include(p => p.Practitioner)
                .Include(p => p.Medications)
                .Include(p => p.Labtest)
                .ToListAsync();
        }

        public async Task<Prescription> GetByIdAsync(int id)
        {
            try 
            { 
                return await _context.Prescriptions
                    .Include(p => p.Patient)
                    .Include(p => p.Practitioner)
                    .Include(p => p.Medications)
                    .Include(p => p.Labtest)
                    .FirstOrDefaultAsync(p => p.Id == id); 
            }
            catch
            {
                return new Prescription();
            }
        }

        public async Task UpdateAsync(Prescription updatedPrescription, int id)
        {
            var prescription = await _context.Prescriptions.FindAsync(id);

            if (prescription == null)
            {
                throw new ArgumentException("Prescription not found");
            }

            prescription.ReasonForVisit = updatedPrescription.ReasonForVisit;
            prescription.Medications = updatedPrescription.Medications;
            prescription.Diseases = updatedPrescription.Diseases;
            prescription.Labtest = updatedPrescription.Labtest;
            prescription.RadiologyTest = updatedPrescription.RadiologyTest;
            prescription.Examination = updatedPrescription.Examination;
            prescription.Reserve = updatedPrescription.Reserve;
            prescription.Surgery = updatedPrescription.Surgery;
            prescription.PatientId = updatedPrescription.PatientId;
            prescription.PractitionerID = updatedPrescription.PractitionerID;

            await _context.SaveChangesAsync();
        }
    }
} 