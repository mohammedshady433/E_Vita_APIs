using E_Vita_APIs.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_Vita_APIs.Repositories
{
    public class UserRepo : IRepositories<User>
    {
        private readonly DBcontext _context;
        public UserRepo(DBcontext context)
        {
            _context = context;
        }
        public async Task AddAsync(User entity)
        {
            await _context.Users.AddAsync(entity);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(string id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }
        public async Task<User> GetByIdAsync(string id)
        {
            try
            {
                return await _context.Users.FindAsync(id);
            }
            catch
            {
                return new User();
            }
        }
        public async Task UpdateAsync(User updatedUser, string id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                throw new ArgumentException("User not found");
            }
            user.Name = updatedUser.Name;
            user.Role = updatedUser.Role;
            user.Password = updatedUser.Password;
            user.DOB = updatedUser.DOB;
            user.Address = updatedUser.Address;
            user.Gender = updatedUser.Gender;
            user.Phone = updatedUser.Phone;
            user.Email = updatedUser.Email;
            user.Nationalality = updatedUser.Nationalality;
            user.degree = updatedUser.degree;
            user.years_of_experience = updatedUser.years_of_experience;
            user.Salary = updatedUser.Salary;

            await _context.SaveChangesAsync();
        }
    }
} 