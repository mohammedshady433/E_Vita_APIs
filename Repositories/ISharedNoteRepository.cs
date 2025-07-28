using E_Vita_APIs.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_Vita_APIs.Repositories
{
    public interface ISharedNoteRepository
    {
        Task<IEnumerable<SharedNote>> GetSharedNotes();
        Task<SharedNote> GetSharedNote(int id);
        Task AddSharedNote(SharedNote sharedNote);
        Task UpdateSharedNote(SharedNote sharedNote);
        Task DeleteSharedNote(int id);
    }
}
