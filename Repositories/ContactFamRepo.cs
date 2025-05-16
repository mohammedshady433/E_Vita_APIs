using E_Vita_APIs.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Vita_APIs.Repositories
{
    public class ContactFamRepo : IRepositories<Contact_fam>
    {
        private readonly DBcontext _context;
        public ContactFamRepo(DBcontext context)
        {
            _context = context;
        }

        public async Task AddAsync(Contact_fam entity)
        {
            await _context.Contact_Fams.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var contactFam = await _context.Contact_Fams.FindAsync(id);
            if (contactFam != null)
            {
                _context.Contact_Fams.Remove(contactFam);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Contact_fam>> GetAllAsync()
        {
            return await _context.Contact_Fams
                .Include(c => c.Patient)
                .ToListAsync();
        }

        public async Task<Contact_fam> GetByIdAsync(int id)
        {
            try 
            { 
                return await _context.Contact_Fams
                    .Include(c => c.Patient)
                    .FirstOrDefaultAsync(c => c.PatientId == id); 
            }
            catch
            {
                return new Contact_fam();
            }
        }

        public async Task UpdateAsync(Contact_fam updatedContactFam, int id)
        {
            var contactFam = await _context.Contact_Fams.FindAsync(id);

            if (contactFam == null)
            {
                throw new ArgumentException("Contact family member not found");
            }

            contactFam.Relationship = updatedContactFam.Relationship;
            contactFam.Name = updatedContactFam.Name;
            contactFam.Phone = updatedContactFam.Phone;
            contactFam.Address = updatedContactFam.Address;
            contactFam.Gender = updatedContactFam.Gender;
            contactFam.PatientId = updatedContactFam.PatientId;

            await _context.SaveChangesAsync();
        }
    }
} 