using Ecommerce_API.Core.Entities;
using Ecommerce_API.Repositories;
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
        public async Task<List<UserEntity>> GetAllUsers()
        {
            return await _userRepository.GetAllUsers();
        }
    }
}
