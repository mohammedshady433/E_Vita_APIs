namespace E_Vita_APIs.Repositories
{
    public interface IRepositories<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(string id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity, string id);
        Task DeleteAsync(string id);
    }
}