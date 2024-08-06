using BusinessLogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserModel>> GetAllUserAsync();
        Task<UserModel> GetUserByIdAsync(int id);
        Task<UserModel> GetUserByEmailAsync(string email);
        Task<string> SignInAsync(string email, string password);
        Task SignUpAsync(string name, string email, string password);
        Task UpdateUserAsync(string name, string email, string password);
        Task DeleteUserAsync(int id);

    }
}
