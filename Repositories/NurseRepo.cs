using E_Vita_APIs.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_Vita_APIs.Repositories
{
    public class NurseRepo : IRepositories<Nurse>
    {
        private readonly DBcontext _context;
        public NurseRepo(DBcontext context)
        {
            _context = context;
        }
        public async Task AddAsync(Nurse entity)
        {
            await _context.Nurses.AddAsync(entity);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(string id)
        {
            var nurse = await _context.Nurses.FindAsync(id);
            if (nurse != null)
            {
                _context.Nurses.Remove(nurse);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<IEnumerable<Nurse>> GetAllAsync()
        {
            return await _context.Nurses.ToListAsync();
        }
        public async Task<Nurse> GetByIdAsync(string id)
        {
            try
            {
                return await _context.Nurses.FindAsync(id);
            }
            catch
            {
                return new Nurse();
            }
        }
        public async Task UpdateAsync(Nurse updatedNurse, string id)
        {
            var nurse = await _context.Nurses.FindAsync(id);
            if (nurse == null)
            {
                throw new ArgumentException("Nurse not found");
            }
            nurse.Salary = updatedNurse.Salary;
            nurse.Rank = updatedNurse.Rank;
            nurse.Speciality = updatedNurse.Speciality;
            await _context.SaveChangesAsync();
        }
    }
} 