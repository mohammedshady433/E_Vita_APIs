using E_Vita_APIs.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Vita_APIs.Repositories
{
    public class ResultsRepo : IRepositories<Models.Results>
    {
        private readonly DBcontext _context;
        public ResultsRepo(DBcontext context)
        {
            _context = context;
        }

        public async Task AddAsync(Models.Results entity)
        {
            await _context.Result.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var result = await _context.Result.FindAsync(id);
            if (result != null)
            {
                _context.Result.Remove(result);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Models.Results>> GetAllAsync()
        {
            return await _context.Result
                .Include(r => r.Lab)
                .Include(r => r.Patient)
                .ToListAsync();
        }

        public async Task<Models.Results> GetByIdAsync(int id)
        {
            try 
            { 
                return await _context.Result
                    .Include(r => r.Lab)
                    .Include(r => r.Patient)
                    .FirstOrDefaultAsync(r => r.ResultId == id); 
            }
            catch
            {
                return new Models.Results();
            }
        }

        public async Task UpdateAsync(Models.Results updatedResult, int id)
        {
            var result = await _context.Result.FindAsync(id);

            if (result == null)
            {
                throw new ArgumentException("Result record not found");
            }

            result.Range = updatedResult.Range;
            result.Date = updatedResult.Date;
            result.TestComponent = updatedResult.TestComponent;
            result.LabId = updatedResult.LabId;
            result.PatientId = updatedResult.PatientId;

            await _context.SaveChangesAsync();
        }
    }
} 