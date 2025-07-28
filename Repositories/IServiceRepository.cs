using E_Vita_APIs.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_Vita_APIs.Repositories
{
    public interface IServiceRepository
    {
        Task<IEnumerable<Service>> GetServices();
        Task<Service> GetService(int id);
        Task AddService(Service service);
        Task UpdateService(Service service);
        Task DeleteService(int id);
    }
}
