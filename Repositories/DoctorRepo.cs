using E_Vita_APIs.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_Vita_APIs.Repositories
{
    public class DoctorRepo : IRepositories<Doctor>
    {
        private readonly DBcontext _context;
        public DoctorRepo(DBcontext context)
        {
            _context = context;
        }
        public async Task AddAsync(Doctor entity)
        {
            await _context.Doctors.AddAsync(entity);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(string id)
        {
            var doctor = await _context.Doctors.FindAsync(id);
            if (doctor != null)
            {
                _context.Doctors.Remove(doctor);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<IEnumerable<Doctor>> GetAllAsync()
        {
            return await _context.Doctors.ToListAsync();
        }
        public async Task<Doctor> GetByIdAsync(string id)
        {
            try
            {
                return await _context.Doctors.FindAsync(id);
            }
            catch
            {
                return new Doctor();
            }
        }
        public async Task UpdateAsync(Doctor updatedDoctor, string id)
        {
            var doctor = await _context.Doctors.FindAsync(id);
            if (doctor == null)
            {
                throw new ArgumentException("Doctor not found");
            }
            doctor.Salary = updatedDoctor.Salary;
            doctor.Rank = updatedDoctor.Rank;
            doctor.Speciality = updatedDoctor.Speciality;
            doctor.ChatId = updatedDoctor.ChatId;
            await _context.SaveChangesAsync();
        }
    }
} 