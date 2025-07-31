using E_Vita_APIs.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_Vita_APIs.Repositories
{
    public class WardRoundRepo : IRepositories<WardRound>
    {
        private readonly DBcontext _context;
        public WardRoundRepo(DBcontext context)
        {
            _context = context;
        }

        public async Task AddAsync(WardRound entity)
        {
            await _context.WardRounds.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var wardRound = await _context.WardRounds.FindAsync(id);
            if (wardRound != null)
            {
                _context.WardRounds.Remove(wardRound);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<WardRound>> GetAllAsync()
        {
            return await _context.WardRounds
                .Include(x => x.Doctor)
                .Include(x => x.Patients)
                .ToListAsync();
        }

        public async Task<WardRound> GetByIdAsync(string id)
        {
            try
            {
                return await _context.WardRounds
                    .Include(x => x.Doctor)
                    .Include(x => x.Patients)
                    .FirstOrDefaultAsync(x => x.Id == id);
            }
            catch
            {
                return new WardRound();
            }
        }

        public async Task UpdateAsync(WardRound updatedWardRound, string id)
        {
            var wardRound = await _context.WardRounds.FindAsync(id);

            if (wardRound == null)
            {
                throw new ArgumentException("WardRound not found");
            }

            wardRound.Date = updatedWardRound.Date;
            wardRound.StartTime = updatedWardRound.StartTime;
            wardRound.EndTime = updatedWardRound.EndTime;
            wardRound.Active = updatedWardRound.Active;
            wardRound.DoctorID = updatedWardRound.DoctorID;
            wardRound.Doctor = updatedWardRound.Doctor;
            wardRound.Patients = updatedWardRound.Patients;
            await _context.SaveChangesAsync();
        }
    }
}
