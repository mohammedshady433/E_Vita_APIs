using E_Vita_APIs.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_Vita_APIs.Repositories
{
    public interface IFamilyHistoryRepository
    {
        Task<IEnumerable<FamilyHistory>> GetFamilyHistories();
        Task<FamilyHistory> GetFamilyHistory(int id);
        Task AddFamilyHistory(FamilyHistory familyHistory);
        Task UpdateFamilyHistory(FamilyHistory familyHistory);
        Task DeleteFamilyHistory(int id);
    }
}
