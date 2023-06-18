using Ecommerce_API.Core.Entities;
using Ecommerce_API.Core.Initial;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce_API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly EcommerceDbContext _context;
        public UserRepository(EcommerceDbContext context)
        {
            _context = context;
        }
        public async Task<List<UserEntity>> GetAllUsers()
        {
            var alluser = await _context.UserEntity.ToListAsync();
            return alluser;
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
