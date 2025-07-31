using E_Vita_APIs.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_Vita_APIs.Repositories
{
    public class ShareRepo : IRepositories<Share>
    {
        private readonly DBcontext _context;
        public ShareRepo(DBcontext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Share>> GetAllAsync()
        {
            return await _context.Shares
                .Include(s => s.Doctor)
                .Include(s => s.Note)
                .Include(s => s.Nurse)
                .Include(s => s.Receptionist)
                .ToListAsync();
        }

        public async Task<Share> GetByIdAsync(string id)
        {
            // Assuming NoteId is the unique identifier for Share
            return await _context.Shares
                .Include(s => s.Doctor)
                .Include(s => s.Note)
                .Include(s => s.Nurse)
                .Include(s => s.Receptionist)
                .FirstOrDefaultAsync(s => s.NoteId == id);
        }

        public async Task AddAsync(Share entity)
        {
            await _context.Shares.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Share updatedEntity, string id)
        {
            var share = await _context.Shares.FirstOrDefaultAsync(s => s.NoteId == id);
            if (share == null)
                throw new ArgumentException("Share not found");

            share.DoctorId = updatedEntity.DoctorId;
            share.NoteId = updatedEntity.NoteId;
            share.NurseId = updatedEntity.NurseId;
            share.ReceptionistId = updatedEntity.ReceptionistId;
            share.Doctor = updatedEntity.Doctor;
            share.Note = updatedEntity.Note;
            share.Nurse = updatedEntity.Nurse;
            share.Receptionist = updatedEntity.Receptionist;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var share = await _context.Shares.FirstOrDefaultAsync(s => s.NoteId == id);
            if (share != null)
            {
                _context.Shares.Remove(share);
                await _context.SaveChangesAsync();
            }
        }
    }
}