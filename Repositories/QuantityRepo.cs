using E_Vita_APIs.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Vita_APIs.Repositories
{
    public class QuantityRepo : IRepositories<Quantity>
    {
        private readonly DBcontext _context;
        public QuantityRepo(DBcontext context)
        {
            _context = context;
        }

        public async Task AddAsync(Quantity entity)
        {
            await _context.Quantities.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var quantity = await _context.Quantities.FindAsync(id);
            if (quantity != null)
            {
                _context.Quantities.Remove(quantity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Quantity>> GetAllAsync()
        {
            return await _context.Quantities
                .Include(q => q.Observation_Vital)
                .ToListAsync();
        }

        public async Task<Quantity> GetByIdAsync(int id)
        {
            try 
            { 
                return await _context.Quantities
                    .Include(q => q.Observation_Vital)
                    .FirstOrDefaultAsync(q => q.Observation_VitalsId == id); 
            }
            catch
            {
                return new Quantity();
            }
        }

        public async Task UpdateAsync(Quantity updatedQuantity, int id)
        {
            var quantity = await _context.Quantities.FindAsync(id);

            if (quantity == null)
            {
                throw new ArgumentException("Quantity record not found");
            }

            quantity.Value = updatedQuantity.Value;
            quantity.Unit = updatedQuantity.Unit;
            quantity.Observation_VitalsId = updatedQuantity.Observation_VitalsId;

            await _context.SaveChangesAsync();
        }
    }
} 