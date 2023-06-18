using Ecommerce_API.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce_API.Repositories
{
    public interface IUserRepository
    {
        Task<UserEntity> GetUserByUserName(string userName);
        Task<UserEntity> GetUserByEmail(string email);
        Task<UserEntity> GetUserById(string userId);
        Task<List<UserEntity>> GetAllUsers();
    }
}
