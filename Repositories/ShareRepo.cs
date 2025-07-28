using E_Vita_APIs.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Vita_APIs.Repositories
{
    public class ShareRepo : IRepositories<Share>
    {
        private readonly DBcontext _context;

        public ShareRepo(DBcontext context)
        {
            _context = context;
        }

        public async Task AddAsync(Share entity)
        {
            await _context.Shares.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var share = await _context.Shares.FindAsync(id);
            if (share != null)
            {
                _context.Shares.Remove(share);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Share>> GetAllAsync()
        {
            return await _context.Shares
                .Include(s => s.DoctorID)
                .Include(s => s.NoteID)
                .Include(s => s.NurseID)
                .Include(s => s.ReceptionistID)
                .ToListAsync();
        }

        public async Task<Share> GetByIdAsync(string id)
        {
            try
            {
                return await _context.Shares
                    .Include(s => s.DoctorID)
                    .Include(s => s.NoteID)
                    .Include(s => s.NurseID)
                    .Include(s => s.ReceptionistID)
                    .FirstOrDefaultAsync(s => s.DoctorId == id || s.NoteID == id || s.NurseID == id || s.ReceptionistId == id);
            }
            catch
            {
                return new Share();
            }
        }

        public async Task UpdateAsync(Share updatedShare, string id)
        {
            var share = await _context.Shares
                .FirstOrDefaultAsync(s => s.DoctorId == id || s.NoteId == id || s.NurseId == id || s.ReceptionistId == id);

            if (share == null)
            {
                throw new ArgumentException("Share not found");
            }

            share.DoctorId = updatedShare.DoctorId;
            share.NoteID = updatedShare.NoteID;
            share.NurseID = updatedShare.NurseID;
            share.ReceptionistId = updatedShare.ReceptionistId;

            await _context.SaveChangesAsync();
        }
    }
}