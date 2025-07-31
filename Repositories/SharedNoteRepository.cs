using E_Vita_APIs.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_Vita_APIs.Repositories
{
    public class SharedNoteRepository : IRepositories<SharedNote>
    {
        private readonly DBcontext _context;
        public SharedNoteRepository(DBcontext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SharedNote>> GetAllAsync()
        {
            return await _context.SharedNotes.ToListAsync();
        }

        public async Task<SharedNote> GetByIdAsync(string id)
        {
            return await _context.SharedNotes.FindAsync(id);
        }

        public async Task AddAsync(SharedNote entity)
        {
            await _context.SharedNotes.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(SharedNote entity, string id)
        {
            var existing = await _context.SharedNotes.FindAsync(id);
            if (existing == null)
                throw new ArgumentException("SharedNote not found");

            existing.Content = entity.Content;
            existing.practitionerID = entity.practitionerID;
            existing.practitioner_type = entity.practitioner_type;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var entity = await _context.SharedNotes.FindAsync(id);
            if (entity != null)
            {
                _context.SharedNotes.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
