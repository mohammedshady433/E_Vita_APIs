using E_Vita_APIs.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Vita_APIs.Repositories
{
    public class SharedNoteRepo : IRepositories<SharedNote>
    {
        private readonly DBcontext _context;
        public SharedNoteRepo(DBcontext context)
        {
            _context = context;
        }

        public async Task AddAsync(SharedNote entity)
        {
            await _context.SharedNotes.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var sharedNote = await _context.SharedNotes.FindAsync(id);
            if (sharedNote != null)
            {
                _context.SharedNotes.Remove(sharedNote);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<SharedNote>> GetAllAsync()
        {
            return await _context.SharedNotes
                .Include(s => s.Practitioner)
                .ToListAsync();
        }

        public async Task<SharedNote> GetByIdAsync(int id)
        {
            try 
            { 
                return await _context.SharedNotes
                    .Include(s => s.Practitioner)
                    .FirstOrDefaultAsync(s => s.Id == id); 
            }
            catch
            {
                return new SharedNote();
            }
        }

        public async Task UpdateAsync(SharedNote updatedSharedNote, int id)
        {
            var sharedNote = await _context.SharedNotes.FindAsync(id);

            if (sharedNote == null)
            {
                throw new ArgumentException("Shared note not found");
            }

            sharedNote.content = updatedSharedNote.content;
            sharedNote.PractitionerID = updatedSharedNote.PractitionerID;

            await _context.SaveChangesAsync();
        }
    }
} 