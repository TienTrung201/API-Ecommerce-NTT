using Ecommerce_API.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce_API.Repositories.Repositories
{
    public interface IUserRepository
    {
        //get
        Task<UserEntity> GetUserByUserName(string userName);
        Task<UserEntity> GetUserByEmail(string email);
        Task<UserEntity> GetUserById(string userId);
        Task<List<UserEntity>> GetAllUsers();
        //add
        Task<UserEntity> CreateUser(UserEntity user);
        //update
        Task<UserEntity> UpdateUser(UserEntity user);

    }
}
