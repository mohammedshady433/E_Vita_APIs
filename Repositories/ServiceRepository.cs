using E_Vita_APIs.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_Vita_APIs.Repositories
{
    public class ServiceRepository : IRepositories<Service>
    {
        private readonly DBcontext _context;
        public ServiceRepository(DBcontext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Service>> GetAllAsync()
        {
            return await _context.Set<Service>().ToListAsync();
        }

        public async Task<Service> GetByIdAsync(string id)
        {
            return await _context.Set<Service>().FindAsync(id);
        }

        public async Task AddAsync(Service entity)
        {
            await _context.Set<Service>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Service entity, string id)
        {
            var existing = await _context.Set<Service>().FindAsync(id);
            if (existing == null)
                throw new ArgumentException("Service not found");

            existing.ServiceName = entity.ServiceName;
            existing.PracticionerID = entity.PracticionerID;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var entity = await _context.Set<Service>().FindAsync(id);
            if (entity != null)
            {
                _context.Set<Service>().Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
