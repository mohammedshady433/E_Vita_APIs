using E_Vita_APIs.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_Vita_APIs.Repositories
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly DBcontext _context;
        public ServiceRepository(DBcontext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Service>> GetServices()
        {
            return await _context.Set<Service>().ToListAsync();
        }
        public async Task<Service> GetService(int id)
        {
            return await _context.Set<Service>().FindAsync(id);
        }
        public async Task AddService(Service service)
        {
            await _context.Set<Service>().AddAsync(service);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateService(Service service)
        {
            _context.Set<Service>().Update(service);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteService(int id)
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
