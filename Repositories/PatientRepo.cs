using E_Vita_APIs.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace E_Vita_APIs.Repositories
{
    class PatientRepo : IRepositories<Patient>
    {
        private readonly DBcontext _context;
        public PatientRepo(DBcontext context)
        {
            _context = context;
        }
        public async Task AddAsync(Patient entity)
        {
            await _context.Patients.AddAsync(entity);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var patient = await _context.Patients.FindAsync(id);
            if (patient != null)
            {
                _context.Patients.Remove(patient);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<IEnumerable<Patient>> GetAllAsync()
        {
            return await _context.Patients.ToListAsync();
        }
        public async Task<Patient> GetByIdAsync(int id)
        {
            try 
            {
                return await _context.Patients.FindAsync(id);
            }
            catch
            {
                return new Patient();
            }
        }
        public async Task UpdateAsync(Patient updatedPatient, int id)
        {
            var patient = await _context.Patients.FindAsync(id);

            if (patient == null)
            {
                // You can throw an exception or return early depending on your requirements
                throw new ArgumentException("Patient not found");
            }

            // Update the properties of the retrieved patient with the new data
            patient.Status = updatedPatient.Status;
            patient.password = updatedPatient.password;
            patient.Address = updatedPatient.Address;
            patient.DateOfBirth = updatedPatient.DateOfBirth;
            patient.Name = updatedPatient.Name;
            patient.Phone = updatedPatient.Phone;
            patient.Email = updatedPatient.Email;
            patient.Gender = updatedPatient.Gender;

            await _context.SaveChangesAsync();
        }
   
    }
}
