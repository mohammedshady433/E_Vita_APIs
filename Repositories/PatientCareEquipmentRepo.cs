using E_Vita_APIs.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_Vita_APIs.Repositories
{
    public class PatientCareEquipmentRepo : IRepositories<PatientCareEquipment>
    {
        private readonly DBcontext _context;
        public PatientCareEquipmentRepo(DBcontext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PatientCareEquipment>> GetAllAsync()
        {
            return await _context.PatientCareEquipments
                .Include(e => e.Bed)
                .ToListAsync();
        }

        public async Task<PatientCareEquipment> GetByIdAsync(string id)
        {
            return await _context.PatientCareEquipments
                .Include(e => e.Bed)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task AddAsync(PatientCareEquipment entity)
        {
            await _context.PatientCareEquipments.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(PatientCareEquipment updatedEntity, string id)
        {
            var equipment = await _context.PatientCareEquipments.FindAsync(id);
            if (equipment == null)
                throw new ArgumentException("PatientCareEquipment not found");

            equipment.DeviceName = updatedEntity.DeviceName;
            equipment.Date_of_Adding = updatedEntity.Date_of_Adding;
            equipment.ExpireDate = updatedEntity.ExpireDate;
            equipment.BedId = updatedEntity.BedId;
            equipment.Bed = updatedEntity.Bed;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var equipment = await _context.PatientCareEquipments.FindAsync(id);
            if (equipment != null)
            {
                _context.PatientCareEquipments.Remove(equipment);
                await _context.SaveChangesAsync();
            }
        }
    }
}