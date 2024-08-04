using BusinessLogicLayer.Interfaces;
using DataAcessLayer.Entities;
using DataAcessLayer.Interfaces;
using BusinessLogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;

        public UserService(IUserRepository userRepository, IAuthService authService)
        {
            _userRepository = userRepository;
            _authService = authService;
        }

        public async Task SignUpAsync(string name, string email, string password)
        {

            var userEntity = await _userRepository.GetUserByEmailAsync(email);
            if (userEntity != null)
            {
                throw new Exception("Usuário já cadastrado!");
            }

            var encryptPassword = password != null ? BCrypt.Net.BCrypt.HashPassword(password) : throw new ArgumentException("Senha não pode ser nula!");

            var entity = new UserEntity
            {
                Name = name,
                Email = email,
                Password = encryptPassword,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.MinValue
            };

            await _userRepository.SignUpAsync(entity);

        }

        public async Task<string> SignInAsync(string email, string password)
        {

            var userEntity = await _userRepository.GetUserByEmailAsync(email);

            if (userEntity != null)
            {
                var user = new UserModel
                {
                    Id = userEntity.Id,
                    Name = userEntity.Name,
                    Email = userEntity.Email
                };

                if (!BCrypt.Net.BCrypt.Verify(password, userEntity.Password))
                {
                    throw new Exception("Credenciais inválidas!");
                }

                return _authService.GenerateJWTToken(user);
            }

            throw new Exception("Usuário não cadastrado!");
        }

        public async Task<IEnumerable<UserModel>> GetAllUserAsync()
        {
            var userEntity = await _userRepository.GetAllUserAsync();

            return userEntity.Select(e => new UserModel
            {
                Id = e.Id,
                Name = e.Name,
                Email = e.Email
            });
        }

        public async Task<UserModel> GetUserByIdAsync(int id)
        {
            var userEntity = await _userRepository.GetUserByIdAsync(id);

            if(userEntity == null)
            {
                throw new Exception("Usuário não cadastrado!");
            }

            return new UserModel
            {
                Id = userEntity.Id,
                Name = userEntity.Name,
                Email = userEntity.Email
            };
        }

        public async Task<UserModel> GetUserByEmailAsync(string email)
        {
            var userEntity = await _userRepository.GetUserByEmailAsync(email);

            if (userEntity == null)
            {
                throw new Exception("Credenciais incorretas!");
            }

            return new UserModel
            {
                Id = userEntity.Id,
                Name = userEntity.Name,
                Email = userEntity.Email
            };
        }

        public async Task UpdateUserAsync(string name, string email, string password)
        {
            var userEntity = await _userRepository.GetUserByEmailAsync(email);
            if (userEntity != null)
            {
                throw new Exception("Usuário não cadastrado!");
            }

            var encryptPassword = password != null ? BCrypt.Net.BCrypt.HashPassword(password) : throw new ArgumentException("Senha não pode ser nula!");

            var entity = new UserEntity
            {
                Name = name,
                Email = email,
                Password = encryptPassword,
                UpdatedAt = DateTime.Now
            };

            await _userRepository.UpdateUserAsync(entity);
        }

        public async Task DeleteUserAsync(int id)
        {
            var userEntity = await _userRepository.GetUserByIdAsync(id);
            if (userEntity != null)
            {
                throw new Exception("Usuário não cadastrado!");
            }
            await _userRepository.DeleteUserAsync(id);
        }
    }
}
