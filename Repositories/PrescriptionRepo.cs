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

        public async Task DeleteAsync(string id)
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
            return await _context.Prescriptions.ToListAsync();
        }

        public async Task<Prescription> GetByIdAsync(string id)
        {
            try 
            { 
                return await _context.Prescriptions.FirstOrDefaultAsync(p => p.Id.Equals(id)); 
            }
            catch
            {
                return new Prescription();
            }
        }

        public async Task UpdateAsync(Prescription updatedPrescription, string id)
        {
            var prescription = await _context.Prescriptions.FindAsync(id);

            if (prescription == null)
            {
                throw new ArgumentException("Prescription not found");
            }

            prescription.Diagnosis = updatedPrescription.Diagnosis;
            prescription.Complaint = updatedPrescription.Complaint;
            prescription.Date = updatedPrescription.Date;
            prescription.Reason_for_visit = updatedPrescription.Reason_for_visit;
            prescription.Doctor_ID = updatedPrescription.Doctor_ID;
            prescription.Patient_ID = updatedPrescription.Patient_ID;
            prescription.Radiologies = updatedPrescription.Radiologies;
            prescription.Labs = updatedPrescription.Labs;

            await _context.SaveChangesAsync();
        }
    }
} 