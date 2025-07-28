using E_Vita_APIs.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_Vita_APIs.Repositories
{
    public class ReceptionistRepo : IRepositories<Receptionist>
    {
        private readonly DBcontext _context;
        public ReceptionistRepo(DBcontext context)
        {
            _context = context;
        }
        public async Task AddAsync(Receptionist entity)
        {
            await _context.Receptionists.AddAsync(entity);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(string id)
        {
            var receptionist = await _context.Receptionists.FindAsync(id);
            if (receptionist != null)
            {
                _context.Receptionists.Remove(receptionist);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<IEnumerable<Receptionist>> GetAllAsync()
        {
            return await _context.Receptionists.ToListAsync();
        }
        public async Task<Receptionist> GetByIdAsync(string id)
        {
            try
            {
                return await _context.Receptionists.FindAsync(id);
            }
            catch
            {
                return new Receptionist();
            }
        }
        public async Task UpdateAsync(Receptionist updatedReceptionist, string id)
        {
            var receptionist = await _context.Receptionists.FindAsync(id);
            if (receptionist == null)
            {
                throw new ArgumentException("Receptionist not found");
            }
            receptionist.StartTime = updatedReceptionist.StartTime;
            receptionist.EndTime = updatedReceptionist.EndTime;
            receptionist.Salary = updatedReceptionist.Salary;
            await _context.SaveChangesAsync();
        }
    }
} 