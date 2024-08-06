using DataAcessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserEntity>> GetAllUserAsync();
        Task<UserEntity?> GetUserByIdAsync(int id);
        Task<UserEntity?> GetUserByEmailAsync(string email);
        Task SignUpAsync(UserEntity user);
        Task UpdateUserAsync(UserEntity user);
        Task DeleteUserAsync(int id);

    }
}
