using E_Vita_APIs.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_Vita_APIs.Repositories
{
    public interface IScreentimeArticleRepository
    {
        Task<IEnumerable<ScreentimeArticle>> GetScreentimeArticles();
        Task<ScreentimeArticle> GetScreentimeArticle(int id);
        Task AddScreentimeArticle(ScreentimeArticle screentimeArticle);
        Task UpdateScreentimeArticle(ScreentimeArticle screentimeArticle);
        Task DeleteScreentimeArticle(int id);
    }
}
