using E_Vita_APIs.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_Vita_APIs.Repositories
{
    public class ScreentimeArticleRepository : IScreentimeArticleRepository
    {
        private readonly DBcontext _context;
        public ScreentimeArticleRepository(DBcontext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ScreentimeArticle>> GetScreentimeArticles()
        {
            return await _context.Set<ScreentimeArticle>().ToListAsync();
        }
        public async Task<ScreentimeArticle> GetScreentimeArticle(int id)
        {
            return await _context.Set<ScreentimeArticle>().FindAsync(id);
        }
        public async Task AddScreentimeArticle(ScreentimeArticle screentimeArticle)
        {
            await _context.Set<ScreentimeArticle>().AddAsync(screentimeArticle);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateScreentimeArticle(ScreentimeArticle screentimeArticle)
        {
            _context.Set<ScreentimeArticle>().Update(screentimeArticle);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteScreentimeArticle(int id)
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
