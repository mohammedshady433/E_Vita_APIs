using E_Vita_APIs.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_Vita_APIs.Repositories
{
    class WardRoundRepo : IRepositories<WardRound>
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

        public async Task DeleteAsync(int id)
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
            return await _context.WardRounds.Include(x => x.Practitioner).ToListAsync();
        }

        public async Task<WardRound> GetByIdAsync(int id)
        {
            try { return await _context.WardRounds.FindAsync(id); }
            catch
            {
                return new WardRound();
            }
        }

        public async Task UpdateAsync(WardRound updatedWardRound, int id)
        {
            var wardRound = await _context.WardRounds.FindAsync(id);

            if (wardRound == null)
            {
                throw new ArgumentException("WardRound not found");
            }

            // Update properties
            wardRound.Date = updatedWardRound.Date;
            wardRound.Time = updatedWardRound.Time;
            wardRound.Note = updatedWardRound.Note;
            wardRound.PractitionerID = updatedWardRound.PractitionerID;
            wardRound.Practitioner = updatedWardRound.Practitioner;

            await _context.SaveChangesAsync();
        }
    }
}
