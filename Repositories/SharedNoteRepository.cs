using E_Vita_APIs.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_Vita_APIs.Repositories
{
    public class SharedNoteRepository : ISharedNoteRepository
    {
        private readonly DBcontext _context;
        public SharedNoteRepository(DBcontext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<SharedNote>> GetSharedNotes()
        {
            return await _context.Set<SharedNote>().ToListAsync();
        }
        public async Task<SharedNote> GetSharedNote(int id)
        {
            return await _context.Set<SharedNote>().FindAsync(id);
        }
        public async Task AddSharedNote(SharedNote sharedNote)
        {
            await _context.Set<SharedNote>().AddAsync(sharedNote);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateSharedNote(SharedNote sharedNote)
        {
            _context.Set<SharedNote>().Update(sharedNote);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteSharedNote(int id)
        {
            var entity = await _context.Set<SharedNote>().FindAsync(id);
            if (entity != null)
            {
                _context.Set<SharedNote>().Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
