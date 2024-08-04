using DataAcessLayer.Data;
using DataAcessLayer.Entities;
using DataAcessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserEntity>> GetAllUserAsync()
        {
            return await _context.tb_user.ToListAsync();
        }

        public async Task<UserEntity?> GetUserByIdAsync(int id)
        {
            return await _context.tb_user.FindAsync(id);
        }

        public async Task<UserEntity?> GetUserByEmailAsync(string email)
        {
            return await _context.tb_user.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task SignUpAsync(UserEntity user)
        {
            await _context.tb_user.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(UserEntity user)
        {
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(int id)
        {
            var user = await _context.tb_user.FindAsync(id);
            if (user != null)
            {
                _context.tb_user.Remove(user);
                await _context.SaveChangesAsync();
            }
        }
    }
}
