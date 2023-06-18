using Ecommerce_API.Core.Entities;
using Ecommerce_API.Core.Initial;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce_API.Repositories.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly EcommerceDbContext _context;
        public UserRepository(EcommerceDbContext context)
        {
            _context = context;
        }

        //create user
        public async Task<UserEntity> CreateUser(UserEntity user)
        {
            await _context.Users.AddAsync(user);
            var result = await _context.SaveChangesAsync();
            if (result == 0)
            {
                throw new Exception("Không thể thêm mới user");
            }
            return user;
        }

        public async Task<List<UserEntity>> GetAllUsers()
        {
            var allUser = await _context.Users.ToListAsync();
            return allUser;
        }

        public Task<UserEntity> GetUserByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Task<UserEntity> GetUserById(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<UserEntity> GetUserByUserName(string userName)
        {
            throw new NotImplementedException();
        }
    }
}
