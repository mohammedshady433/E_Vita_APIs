using E_Vita_APIs.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Vita_APIs.Repositories
{
    public class ObservationVitalRepo : IRepositories<Observation_Vital>
    {
        private readonly DBcontext _context;
        public ObservationVitalRepo(DBcontext context)
        {
            _context = context;
        }

        public async Task AddAsync(Observation_Vital entity)
        {
            await _context.observation_Vitals.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var observationVital = await _context.observation_Vitals.FindAsync(id);
            if (observationVital != null)
            {
                _context.observation_Vitals.Remove(observationVital);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Observation_Vital>> GetAllAsync()
        {
            return await _context.observation_Vitals.ToListAsync();
        }

        public async Task<Observation_Vital> GetByIdAsync(int id)
        {
            try 
            { 
                return await _context.observation_Vitals.FindAsync(id); 
            }
            catch
            {
                return new Observation_Vital();
            }
        }

        public async Task UpdateAsync(Observation_Vital updatedObservationVital, int id)
        {
            var observationVital = await _context.observation_Vitals.FindAsync(id);

            if (observationVital == null)
            {
                throw new ArgumentException("Observation vital record not found");
            }

            observationVital.Method = updatedObservationVital.Method;
            observationVital.Note = updatedObservationVital.Note;
            observationVital.Category = updatedObservationVital.Category;
            observationVital.Date = updatedObservationVital.Date;

            await _context.SaveChangesAsync();
        }
    }
} 