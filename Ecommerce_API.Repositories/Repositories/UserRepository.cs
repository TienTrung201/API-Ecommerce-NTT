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
                throw new Exception("Không thể thêm mới người dùng");
            }
            return user;
        }
        //getAllUsers
        public async Task<List<UserEntity>> GetAllUsers()
        {
            var allUser = await _context.Users.ToListAsync();
            return allUser;
        }

        public async Task<UserEntity> GetUserByEmail(string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user == null)
            {
                throw new Exception("Không thể tìm thấy người dùng");
            }
            return user;
        }

        public async Task<UserEntity> GetUserById(string userId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == userId);
            if (user == null)
            {
                throw new Exception("Không thể tìm thấy người dùng");
            }
            return user;
        }

        public async Task<UserEntity> GetUserByUserName(string userName)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName.ToLower() == userName.ToLower());
            if (user == null)
            {
                throw new Exception("Không thể tìm thấy người dùng");
            }
            return user;
        }

        //update
        public async Task<UserEntity> UpdateUser(UserEntity user)
        {
            _context.Users.Update(user);
            var result = await _context.SaveChangesAsync();
            if (result == 0)
            {
                throw new Exception("Không thể cập nhật người dùng");
            }
            return user;
        }
    }
}
