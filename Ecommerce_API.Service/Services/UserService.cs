using Ecommerce_API.Core.Entities;
using Ecommerce_API.Repositories.Repositories;
using Ecommerce_API.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce_API.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserEntity> CreateUser(UserRequestDto userRequestDto)
        {
            var newUser = new UserEntity()
            {
                UserName = userRequestDto.UserName,
                Email = userRequestDto.Email,
                Password = userRequestDto.Password,
                FullName = userRequestDto.FullName,

            };
            var createUser = await _userRepository.CreateUser(newUser);
            return createUser;
        }

        public async Task<List<UserEntity>> GetAllUsers()
        {
            return await _userRepository.GetAllUsers();
        }
    }
}
