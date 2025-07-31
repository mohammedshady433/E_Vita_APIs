using E_Vita_APIs.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_Vita_APIs.Repositories
{
    public class ScreentimeArticleRepository : IRepositories<ScreentimeArticle>
    {
        private readonly DBcontext _context;
        public ScreentimeArticleRepository(DBcontext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ScreentimeArticle>> GetAllAsync()
        {
            return await _context.Set<ScreentimeArticle>().ToListAsync();
        }

        public async Task<ScreentimeArticle> GetByIdAsync(string id)
        {
            return await _context.Set<ScreentimeArticle>().FindAsync(id);
        }

        public async Task AddAsync(ScreentimeArticle entity)
        {
            await _context.Set<ScreentimeArticle>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ScreentimeArticle entity, string id)
        {
            var existing = await _context.Set<ScreentimeArticle>().FindAsync(id);
            if (existing == null)
                throw new ArgumentException("ScreentimeArticle not found");

            existing.Articles = entity.Articles;
            existing.Time = entity.Time;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var entity = await _context.Set<ScreentimeArticle>().FindAsync(id);
            if (entity != null)
            {
                _context.Set<ScreentimeArticle>().Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
